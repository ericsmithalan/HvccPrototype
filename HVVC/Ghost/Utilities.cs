using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ghost
{
    public class Utilities
    {
        public static BitmapSource GetBitmapSourceFromGhostApplicationPath(String path)
        {
            Uri uri = new Uri(String.Format("pack://application:,,,/Ghost;component/images/{0}", path), UriKind.Absolute);
            PngBitmapDecoder decoder = new PngBitmapDecoder(uri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }

        public static BitmapSource GetBitmapSourceFromUrlPath(String path)
        {
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(path);
            myBitmapImage.EndInit();
            return myBitmapImage;
        }

        //Get all controls under parent.
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        //Exporting canvas to PNG image
        public void ExportToPng(Uri path, Canvas surface)
        {
            if (path == null)
            {
                return;
            }

            // Save current canvas transform
            Transform transform = surface.LayoutTransform;
            // reset current transform (in case it is scaled or rotated)
            surface.LayoutTransform = null;

            // Get the size of canvas
            Size size = new Size(surface.Width, surface.Height);
            // Measure and arrange the surface
            // VERY IMPORTANT
            surface.Measure(size);
            surface.Arrange(new Rect(size));

            // Create a render bitmap and push the surface to it
            RenderTargetBitmap renderBitmap =
              new RenderTargetBitmap(
                (int)size.Width,
                (int)size.Height,
                96d,
                96d,
                PixelFormats.Pbgra32);
            renderBitmap.Render(surface);

            // Create a file stream for saving image
            using (FileStream outStream = new FileStream(path.LocalPath, FileMode.Create))
            {
                // Use png encoder for our data
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                // push the rendered bitmap to it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                // save the data to the stream
                encoder.Save(outStream);
            }

            // Restore previously saved layout
            surface.LayoutTransform = transform;
        }

        //Exporting canvas to XPS document
        //public void Export(Uri path, Canvas surface)
        //{
        //    if (path == null) return;

        //    // Save current canvas transorm
        //    Transform transform = surface.LayoutTransform;
        //    // Temporarily reset the layout transform before saving
        //    surface.LayoutTransform = null;

        //    // Get the size of the canvas
        //    Size size = new Size(surface.Width, surface.Height);
        //    // Measure and arrange elements
        //    surface.Measure(size);
        //    surface.Arrange(new Rect(size));

        //    // Open new package
        //    Package package = Package.Open(path.LocalPath, FileMode.Create);
        //    // Create new xps document based on the package opened
        //    XpsDocument doc = new XpsDocument(package);
        //    // Create an instance of XpsDocumentWriter for the document
        //    XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
        //    // Write the canvas (as Visual) to the document
        //    writer.Write(surface);
        //    // Close document
        //    doc.Close();
        //    // Close package
        //    package.Close();

        //    // Restore previously saved layout
        //    surface.LayoutTransform = transform;
        //}

        //Exporting canvas to the XAML
        public void Export(Uri path, Canvas surface)
        {
            if (path == null)
            {
                return;
            }

            if (surface == null)
            {
                return;
            }

            string xaml = XamlWriter.Save(surface);
            File.WriteAllText(path.LocalPath, xaml);
        }
    }
}