using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ghost.Imaging
{
    public class Capture
    {
        public static bool CaptureControlImageAndSave(FrameworkElement ctl)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = Path.GetFullPath(saveFileDialog1.FileName);
                using (Stream stream = File.Create(filePath))
                {
                    GetPngEncoder(ctl).Save(stream);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CaptureControlImageAndSave(FrameworkElement ctl, String path)
        {
            using (Stream stream = File.Create(path))
            {
                GetPngEncoder(ctl).Save(stream);
            }
        }

        public static void CaptureControlImageToClipboard(FrameworkElement ctl)
        {
            MemoryStream fs = new MemoryStream();
            GetPngEncoder(ctl).Save(fs);
            System.Drawing.Image imgToCopy = System.Drawing.Image.FromStream(fs);
            System.Windows.Forms.Clipboard.SetImage(imgToCopy);
            imgToCopy.Dispose();
            fs.Close();
            fs.Dispose();
        }

        public static void CombineImagesInDirectory(String directoryPath, string imageName)
        {
            List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
            System.Drawing.Bitmap finalImage = null;
            String[] files = Directory.GetFiles(directoryPath);
            try
            {
                int width = 0;
                int height = 0;

                foreach (string image in files)
                {
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(image);

                    width += bitmap.Width;
                    height = bitmap.Height > height ? bitmap.Height : height;
                    images.Add(bitmap);
                }

                finalImage = new System.Drawing.Bitmap(width, height);
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    g.Clear(System.Drawing.Color.White);
                    int offset = 0;
                    foreach (System.Drawing.Bitmap image in images)
                    {
                        g.DrawImage(image,
                          new System.Drawing.Rectangle(offset, 0, image.Width, image.Height));
                        offset += image.Width;
                    }
                }
                finalImage.Save(String.Format("{0}\\{1}.png", directoryPath, imageName), System.Drawing.Imaging.ImageFormat.Png);
                finalImage.Dispose();
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                {
                    finalImage.Dispose();
                }

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (System.Drawing.Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }

        private static PngBitmapEncoder GetPngEncoder(FrameworkElement ctl)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)ctl.ActualWidth, (int)ctl.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(ctl);

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            return encoder;
        }
    }
}