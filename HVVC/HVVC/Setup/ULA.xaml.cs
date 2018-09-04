using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace HVCC.Setup
{
    /// <summary>
    /// Interaction logic for TOS.xaml
    /// </summary>
    public partial class ULA : UserControl
    {
        public ULA()
        {
            InitializeComponent();

            #region RTFString

            String rtf = @"{\rtf1\adeflang1025\ansi\ansicpg1252\uc1\adeff0\deff0\stshfdbch0\stshfloch0\stshfhich0\stshfbi0\deflang1033\deflangfe1033\themelang1033\themelangfe0\themelangcs0{\fonttbl{\f0\fbidi \froman\fcharset0\fprq2{\*\panose 02020603050405020304}Times New Roman;}{\f2\fbidi \fmodern\fcharset0\fprq1{\*\panose 02070309020205020404}Courier New;}
{\f3\fbidi \froman\fcharset2\fprq2{\*\panose 05050102010706020507}Symbol;}{\f34\fbidi \froman\fcharset0\fprq2{\*\panose 02040503050406030204}Cambria Math;}{\f38\fbidi \fswiss\fcharset0\fprq2{\*\panose 020b0604030504040204}Tahoma;}
{\f39\fbidi \fswiss\fcharset0\fprq2{\*\panose 020b0603020202020204}Trebuchet MS;}{\flomajor\f31500\fbidi \froman\fcharset0\fprq2{\*\panose 02020603050405020304}Times New Roman;}
{\fdbmajor\f31501\fbidi \froman\fcharset0\fprq2{\*\panose 02020603050405020304}Times New Roman;}{\fhimajor\f31502\fbidi \froman\fcharset0\fprq2{\*\panose 02040503050406030204}Cambria;}
{\fbimajor\f31503\fbidi \froman\fcharset0\fprq2{\*\panose 02020603050405020304}Times New Roman;}{\flominor\f31504\fbidi \froman\fcharset0\fprq2{\*\panose 02020603050405020304}Times New Roman;}
{\fdbminor\f31505\fbidi \froman\fcharset0\fprq2{\*\panose 02020603050405020304}Times New Roman;}{\fhiminor\f31506\fbidi \fswiss\fcharset0\fprq2{\*\panose 020f0502020204030204}Calibri;}
{\fbiminor\f31507\fbidi \froman\fcharset0\fprq2{\*\panose 02020603050405020304}Times New Roman;}{\f40\fbidi \froman\fcharset238\fprq2 Times New Roman CE;}{\f41\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}
{\f43\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}{\f44\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\f45\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}{\f46\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}
{\f47\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\f48\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}{\f60\fbidi \fmodern\fcharset238\fprq1 Courier New CE;}{\f61\fbidi \fmodern\fcharset204\fprq1 Courier New Cyr;}
{\f63\fbidi \fmodern\fcharset161\fprq1 Courier New Greek;}{\f64\fbidi \fmodern\fcharset162\fprq1 Courier New Tur;}{\f65\fbidi \fmodern\fcharset177\fprq1 Courier New (Hebrew);}{\f66\fbidi \fmodern\fcharset178\fprq1 Courier New (Arabic);}
{\f67\fbidi \fmodern\fcharset186\fprq1 Courier New Baltic;}{\f68\fbidi \fmodern\fcharset163\fprq1 Courier New (Vietnamese);}{\f380\fbidi \froman\fcharset238\fprq2 Cambria Math CE;}{\f381\fbidi \froman\fcharset204\fprq2 Cambria Math Cyr;}
{\f383\fbidi \froman\fcharset161\fprq2 Cambria Math Greek;}{\f384\fbidi \froman\fcharset162\fprq2 Cambria Math Tur;}{\f387\fbidi \froman\fcharset186\fprq2 Cambria Math Baltic;}{\f420\fbidi \fswiss\fcharset238\fprq2 Tahoma CE;}
{\f421\fbidi \fswiss\fcharset204\fprq2 Tahoma Cyr;}{\f423\fbidi \fswiss\fcharset161\fprq2 Tahoma Greek;}{\f424\fbidi \fswiss\fcharset162\fprq2 Tahoma Tur;}{\f425\fbidi \fswiss\fcharset177\fprq2 Tahoma (Hebrew);}
{\f426\fbidi \fswiss\fcharset178\fprq2 Tahoma (Arabic);}{\f427\fbidi \fswiss\fcharset186\fprq2 Tahoma Baltic;}{\f428\fbidi \fswiss\fcharset163\fprq2 Tahoma (Vietnamese);}{\f429\fbidi \fswiss\fcharset222\fprq2 Tahoma (Thai);}
{\f430\fbidi \fswiss\fcharset238\fprq2 Trebuchet MS CE;}{\f431\fbidi \fswiss\fcharset204\fprq2 Trebuchet MS Cyr;}{\f433\fbidi \fswiss\fcharset161\fprq2 Trebuchet MS Greek;}{\f434\fbidi \fswiss\fcharset162\fprq2 Trebuchet MS Tur;}
{\f437\fbidi \fswiss\fcharset186\fprq2 Trebuchet MS Baltic;}{\flomajor\f31508\fbidi \froman\fcharset238\fprq2 Times New Roman CE;}{\flomajor\f31509\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}
{\flomajor\f31511\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}{\flomajor\f31512\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\flomajor\f31513\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}
{\flomajor\f31514\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}{\flomajor\f31515\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\flomajor\f31516\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}
{\fdbmajor\f31518\fbidi \froman\fcharset238\fprq2 Times New Roman CE;}{\fdbmajor\f31519\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}{\fdbmajor\f31521\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}
{\fdbmajor\f31522\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\fdbmajor\f31523\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}{\fdbmajor\f31524\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}
{\fdbmajor\f31525\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\fdbmajor\f31526\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}{\fhimajor\f31528\fbidi \froman\fcharset238\fprq2 Cambria CE;}
{\fhimajor\f31529\fbidi \froman\fcharset204\fprq2 Cambria Cyr;}{\fhimajor\f31531\fbidi \froman\fcharset161\fprq2 Cambria Greek;}{\fhimajor\f31532\fbidi \froman\fcharset162\fprq2 Cambria Tur;}
{\fhimajor\f31535\fbidi \froman\fcharset186\fprq2 Cambria Baltic;}{\fbimajor\f31538\fbidi \froman\fcharset238\fprq2 Times New Roman CE;}{\fbimajor\f31539\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}
{\fbimajor\f31541\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}{\fbimajor\f31542\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\fbimajor\f31543\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}
{\fbimajor\f31544\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}{\fbimajor\f31545\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\fbimajor\f31546\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}
{\flominor\f31548\fbidi \froman\fcharset238\fprq2 Times New Roman CE;}{\flominor\f31549\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}{\flominor\f31551\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}
{\flominor\f31552\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\flominor\f31553\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}{\flominor\f31554\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}
{\flominor\f31555\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\flominor\f31556\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}{\fdbminor\f31558\fbidi \froman\fcharset238\fprq2 Times New Roman CE;}
{\fdbminor\f31559\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}{\fdbminor\f31561\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}{\fdbminor\f31562\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}
{\fdbminor\f31563\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}{\fdbminor\f31564\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}{\fdbminor\f31565\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}
{\fdbminor\f31566\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}{\fhiminor\f31568\fbidi \fswiss\fcharset238\fprq2 Calibri CE;}{\fhiminor\f31569\fbidi \fswiss\fcharset204\fprq2 Calibri Cyr;}
{\fhiminor\f31571\fbidi \fswiss\fcharset161\fprq2 Calibri Greek;}{\fhiminor\f31572\fbidi \fswiss\fcharset162\fprq2 Calibri Tur;}{\fhiminor\f31575\fbidi \fswiss\fcharset186\fprq2 Calibri Baltic;}
{\fbiminor\f31578\fbidi \froman\fcharset238\fprq2 Times New Roman CE;}{\fbiminor\f31579\fbidi \froman\fcharset204\fprq2 Times New Roman Cyr;}{\fbiminor\f31581\fbidi \froman\fcharset161\fprq2 Times New Roman Greek;}
{\fbiminor\f31582\fbidi \froman\fcharset162\fprq2 Times New Roman Tur;}{\fbiminor\f31583\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}{\fbiminor\f31584\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}
{\fbiminor\f31585\fbidi \froman\fcharset186\fprq2 Times New Roman Baltic;}{\fbiminor\f31586\fbidi \froman\fcharset163\fprq2 Times New Roman (Vietnamese);}}{\colortbl;\red0\green0\blue0;\red0\green0\blue255;\red0\green255\blue255;\red0\green255\blue0;
\red255\green0\blue255;\red255\green0\blue0;\red255\green255\blue0;\red255\green255\blue255;\red0\green0\blue128;\red0\green128\blue128;\red0\green128\blue0;\red128\green0\blue128;\red128\green0\blue0;\red128\green128\blue0;\red128\green128\blue128;
\red192\green192\blue192;}{\*\defchp }{\*\defpap \ql \li0\ri0\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0 }\noqfpromote {\stylesheet{\ql \li0\ri0\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0
\rtlch\fcs1 \af0\afs24\alang1025 \ltrch\fcs0 \fs24\lang1033\langfe1033\loch\f0\hich\af0\dbch\af31505\cgrid\langnp1033\langfenp1033 \snext0 \sqformat \spriority0 Normal;}{\*\cs10 \additive \ssemihidden \sunhideused \spriority1 Default Paragraph Font;}{\*
\ts11\tsrowd\trftsWidthB3\trpaddl108\trpaddr108\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\trcbpat1\trcfpat1\tblind0\tblindtype3\tscellwidthfts0\tsvertalt\tsbrdrt\tsbrdrl\tsbrdrb\tsbrdrr\tsbrdrdgl\tsbrdrdgr\tsbrdrh\tsbrdrv
\ql \li0\ri0\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0 \rtlch\fcs1 \af0\afs20\alang1025 \ltrch\fcs0 \fs20\lang1033\langfe1033\cgrid\langnp1033\langfenp1033 \snext11 \ssemihidden \sunhideused \sqformat Normal Table;}}
{\*\rsidtbl \rsid1841690\rsid2571054\rsid4537554}{\mmathPr\mmathFont34\mbrkBin0\mbrkBinSub0\msmallFrac0\mdispDef1\mlMargin0\mrMargin0\mdefJc1\mwrapIndent1440\mintLim0\mnaryLim1}{\info{\author erics}{\operator erics}{\creatim\yr2009\mo5\dy19\hr17\min1}
{\revtim\yr2009\mo5\dy19\hr17\min7}{\version4}{\edmins4}{\nofpages1}{\nofwords1413}{\nofchars7589}{\*\company Microsoft}{\nofcharsws8985}{\vern32895}}{\*\xmlnstbl {\xmlns1 http://schemas.microsoft.com/office/word/2003/wordml}}
\paperw12240\paperh15840\margl1440\margr1440\margt1440\margb1440\gutter0\ltrsect
\widowctrl\ftnbj\aenddoc\trackmoves1\trackformatting1\donotembedsysfont1\relyonvml0\donotembedlingdata0\grfdocevents0\validatexml1\showplaceholdtext0\ignoremixedcontent0\saveinvalidxml0\showxmlerrors1\noxlattoyen
\expshrtn\noultrlspc\dntblnsbdb\nospaceforul\formshade\horzdoc\dgmargin\dghspace180\dgvspace180\dghorigin148\dgvorigin0\dghshow1\dgvshow1
\jexpand\viewkind5\viewscale101\pgbrdrhead\pgbrdrfoot\splytwnine\ftnlytwnine\htmautsp\nolnhtadjtbl\useltbaln\alntblind\lytcalctblwd\lyttblrtgr\lnbrkrule\nobrkwrptbl\snaptogridincell\allowfieldendsel\wrppunct
\asianbrkrule\nojkernpunct\rsidroot4537554\newtblstyruls\nogrowautofit\usenormstyforlist\noindnmbrts\felnbrelev\nocxsptable\indrlsweleven\noafcnsttbl\afelev\utinl\hwelev\spltpgpar\notcvasp\notbrkcnstfrctbl\notvatxbx\krnprsnet\cachedcolbal
\nouicompat \fet0{\*\wgrffmtfilter 2450}\nofeaturethrottle1\ilfomacatclnup0\ltrpar \sectd \ltrsect\linex0\sectdefaultcl\sectrsid15431318\sftnbj {\*\pnseclvl1\pnucrm\pnstart1\pnindent720\pnhang {\pntxta .}}{\*\pnseclvl2\pnucltr\pnstart1\pnindent720\pnhang
{\pntxta .}}{\*\pnseclvl3\pndec\pnstart1\pnindent720\pnhang {\pntxta .}}{\*\pnseclvl4\pnlcltr\pnstart1\pnindent720\pnhang {\pntxta )}}{\*\pnseclvl5\pndec\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl6\pnlcltr\pnstart1\pnindent720\pnhang
{\pntxtb (}{\pntxta )}}{\*\pnseclvl7\pnlcrm\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl8\pnlcltr\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl9\pnlcrm\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}
\pard\plain \ltrpar\ql \li0\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin0\itap0\pararsid2571054 \rtlch\fcs1 \af0\afs24\alang1025 \ltrch\fcs0 \fs24\lang1033\langfe1033\loch\af0\hich\af0\dbch\af31505\cgrid\langnp1033\langfenp1033 {\rtlch\fcs1
\ab\af38\afs28 \ltrch\fcs0 \b\f38\fs28\insrsid2571054 MICROSOFT PRE-RELEASE SOFTWARE LICENSE TERMS
\par }\pard \ltrpar\ql \li0\ri0\sb120\sa120\widctlpar\brdrb\brdrs\brdrw10\brsp20 \wrapdefault\faauto\rin0\lin0\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af38\afs28 \ltrch\fcs0 \b\f38\fs28\insrsid2571054
MICROSOFT HEALTHVAULT CONNECTION CENTER AND HEALTHVAULT GADGET}{\rtlch\fcs1 \ab\af0\afs28 \ltrch\fcs0 \b\fs28\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \li0\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin0\itap0\pararsid2571054 {\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
These license terms are an agreement between Microsoft Corporation (or based on where you live, one of its affiliates) and you.  Please read them.  They apply to the software named above, which includes the media on which you received it, if any.  The ter
ms also apply to any Microsoft
\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\tx720\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
updates,
\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 supplements,

\par }{\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 Internet-based services, and
\par }{\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 support services
\par }\pard \ltrpar\ql \li0\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin0\itap0\pararsid2571054 {\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 for this software, unless other terms accompany those items.  If so, those terms apply.

\par }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054 BY USING THE SOFTWARE, YOU ACCEPT THESE TERMS.  IF YOU DO NOT ACCEPT THEM, DO NOT USE THE SOFTWARE.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054 AS DESCRIBED BELOW, USING SOME FEATURES ALSO OPERATES AS YOUR CONSENT TO THE TRANSMISSION OF CERTAIN STANDARD COMPUTER INFORMATION FOR INTERNET-BASED SERVICES.}{\rtlch\fcs1 \ab\af0\afs19
\ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \li0\ri0\sb120\sa120\widctlpar\brdrt\brdrs\brdrw10\brsp20 \wrapdefault\faauto\rin0\lin0\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054 If you comply with these license terms, you have the righ
ts below.
\par }\pard \ltrpar\ql \fi-357\li357\ri0\sb120\sa120\widctlpar\tx360\wrapdefault\faauto\rin0\lin357\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 1.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\f38\fs19\insrsid2571054 INSTALLATION AND USE RIGHTS.  }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 You may install and use one copy of the software on your computer to transfer data into your HealthVault account}{\rtlch\fcs1
\af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054 .}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-357\li357\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin357\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 2.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054
INTERNET-BASED SERVICES.  }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 Microsoft provides Internet-based services with the software.  It may change or cancel them at any time.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0
\b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\tx720\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 a.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\f38\fs19\insrsid2571054 Consent for Internet-Based Services.  }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
The software features described below connect to Microsoft or service provider computer systems over the Internet.  In some cases, you will not receive a separate notice when they
connect.  For more information about these features, see the HealthVault Connection Center online help.  By using these features, you consent to the transmission of this information. Microsoft does not use the information to identify or contact you.

\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 b.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054
Computer Information.  }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
The following features use Internet protocols, which send to the appropriate systems computer information, such as your Internet protocol address, the type of operating system, browser and name and version of the software you are using,
 and the language code of the device where you installed the software.  Microsoft uses this information to make the Internet-based service available to you.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-358\li1080\ri0\sb120\sa120\widctlpar\tx1080\wrapdefault\faauto\rin0\lin1080\itap0\pararsid2571054 {\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\ul\insrsid2571054
Transfer to HealthVault Account}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
. HealthVault Connection Center is designed to transfer data from your device or gadget, via your computer, to your HealthVault account. You can control whether to have this happen automatically, or only when you choose.
\par }\pard \ltrpar\ql \fi-358\li1080\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin1080\itap0\pararsid2571054 {\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\ul\insrsid2571054
Microsoft Update Feature}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 .  You may use Microsoft Update to receive updates for new versions of the software. You can control whether to have this happen automatically, or only when you choose}
{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054 .}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\ul\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-358\li1080\ri0\sb120\widctlpar\tx1080\wrapdefault\faauto\rin0\lin1080\itap0\pararsid2571054 {\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\ul\insrsid2571054
Information Updates}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 . HealthVault Connection Center will automatically download updates from HealthVault that may include:}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\ul\dbch\af0\insrsid2571054

\par }\pard \ltrpar\ql \fi-360\li1440\ri0\widctlpar\tx1440\tx1800\wrapdefault\faauto\rin0\lin1440\itap0\pararsid2571054 {\rtlch\fcs1 \af2\afs19 \ltrch\fcs0 \f2\fs19\insrsid2571054 o\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
ability to get data from new types of devices that are compatible with HealthVault}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-360\li1440\ri0\widctlpar\wrapdefault\faauto\rin0\lin1440\itap0\pararsid2571054 {\rtlch\fcs1 \af2\afs19 \ltrch\fcs0 \f2\fs19\insrsid2571054 o\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
information about new types of devices that you can install using HealthVault Connection Center}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\ul\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \af2\afs19 \ltrch\fcs0 \f2\fs19\insrsid2571054 o\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
updates to the list of programs that connect with HealthVault and use the type of data you upload using HealthVault Connection Center}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054 .}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0
\f38\fs19\insrsid2571054  }{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\ul\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\tx720\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 c.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\f38\fs19\insrsid2571054 Misuse of Internet-based Services}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 .  You may not use this service in any way that could harm it or impair anyone else\rquote
s use of it.  You may not use the service to try to gain unauthorized access to any service, data, account or network by any means.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-357\li357\ri0\sb120\sa120\widctlpar\tx360\wrapdefault\faauto\rin0\lin357\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 3.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\f38\fs19\insrsid2571054 PRE-RELEASE SOFTWARE. }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054  This software is a pre-release version.  It may not work the way a
 final version of the software will.  We may change it for the final, commercial version.  We also may not release a commercial version.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-357\li357\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin357\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 4.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054
FEEDBACK. }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054  If you give feedback about the software to Microsoft, you give to Microsoft, without charge, the right to
 use, share and commercialize your feedback in any way and for any purpose.  You also give to third parties, without charge, any patent rights needed for their products, technologies and services to use or interface with any specific parts of a Microsoft
s
oftware or service that includes the feedback.  You will not give feedback that is subject to a license that requires Microsoft to license its software or documentation to third parties because we include your feedback in them.  These rights survive this
agreement.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-357\li357\ri0\sb120\sa120\widctlpar\tx360\wrapdefault\faauto\rin0\lin357\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\caps\f39\fs20\insrsid2571054 5.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\caps\f38\fs19\insrsid2571054 Scope of License}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054 .}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
  The software is licensed, not sold. This agreement only gives you some rights to use the software.  Microsoft reserves all other rights.  Unless app
licable law gives you more rights despite this limitation, you may use the software only as expressly permitted in this agreement.  In doing so, you must comply with any technical limitations in the software that only allow you to use it in certain ways.
   You may not}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\tx720\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
work around any technical limitations in the software;}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
reverse engineer, decompile or disassemble the software, except and only to the extent that applicable law expressly permits, despite this limitation;}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 make more copies of the software than specified in this agreement or allowed by applicable law, despite this limitation;}{
\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 publish the software for others to copy;}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 rent, lease or lend the software;}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 transfer the software or this agreement to any third party; or}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0
\fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 use the software for commercial software hosting services}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0
\fs19\dbch\af0\insrsid2571054 .
\par }\pard \ltrpar\ql \fi-357\li357\ri0\sb120\sa120\widctlpar\tx360\wrapdefault\faauto\rin0\lin357\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 6.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\f38\fs19\insrsid2571054 BACKUP COPY.}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054   You may make one backup copy of the software.  You may use it only to reinstall the software.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0
\b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-357\li357\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin357\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 7.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054
DOCUMENTATION.}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054   Any person that has valid access to your computer or internal network may copy and use the documentation for your internal, reference purposes.}{\rtlch\fcs1 \ab\af0\afs19
\ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 8.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054 TRANSFER TO ANOTHER DEVICE.}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
  You may uninstall the software and install it on another device for your use.  You may not do so to share this license between devices.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\caps\f39\fs20\insrsid2571054 9.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\caps\f38\fs19\insrsid2571054 Export Restrictions}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054 .}{
\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
  The software is subject to United States export laws and regulations.  You must comply with all domestic and international export laws and regulations that apply to the software.  These laws include restrictions on destinations, en
d users and end use.  For additional information, see www.microsoft.com/exporting}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054 .}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\caps\f39\fs20\insrsid2571054 10.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\caps\f38\fs19\insrsid2571054 SUPPORT SERVICES.}{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054  }{\rtlch\fcs1
\af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 Because this software is \'93as is,\'94 we may not provide support services for it.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 11.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054 MICROSOFT .NET BENCHMARK TESTING}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054 .}{
\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054   }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 The software includes one or more components of the .NET Framework (\'93.NET Components\'94
).  You may conduct internal benchmark testing of those components.  You may disclose the results of any benchmark test of those components, provided that you comply with the conditions set forth at http://go.microsoft.com/fwlink/?LinkID=66406}{
\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054 . }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
 Notwithstanding any other agreement you may have with Microsoft, if you disclose such benchmark test results, Microsoft shall have the right to disclose the results of benchmark tes
ts it conducts of your products that compete with the applicable .NET Component, provided it complies with the same conditions set forth at http://go.microsoft.com/fwlink/?LinkID=66406}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054 .}{
\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }{\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\caps\f39\fs20\insrsid2571054 12.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\caps\f38\fs19\insrsid2571054 Entire Agreement.}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
  This agreement, and the terms for supplements, updates, Internet-based services and support services that you use, are the entire agreement for the software and support services.
\par }\pard \ltrpar\ql \fi-360\li360\ri0\sb120\sa120\keepn\widctlpar\wrapdefault\faauto\rin0\lin360\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\caps\f39\fs20\cf1\insrsid2571054 13.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\caps\f38\fs19\cf1\insrsid2571054 Applicable Law}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\cf1\dbch\af0\insrsid2571054 .
\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\tx720\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 a.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\f38\fs19\insrsid2571054 United States.}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054   If you acquired the software in the United States, Washington state law governs the i
nterpretation of this agreement and applies to claims for breach of it, regardless of conflict of laws principles.  The laws of the state where you live govern all other claims, including claims under state consumer protection laws, unfair competition law
s, and in tort.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\f39\fs20\insrsid2571054 b.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054
Outside the United States.}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054   If you acquired the software in any other country, the laws of that country apply.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-357\li357\ri0\sb120\sa120\widctlpar\tx360\wrapdefault\faauto\rin0\lin357\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\caps\f39\fs20\insrsid2571054 14.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\caps\f38\fs19\insrsid2571054 Legal Effect.}{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
  This agreement describes certain legal rights.  You may have other rights under the laws of your country.  You may also have rights with respect to the party from whom you acquired the software.  This agreement does not change your rights under the laws
 of your country if the laws of your country do not permit it to do so.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\caps\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-357\li357\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin357\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\caps\f39\fs20\insrsid2571054 15.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\caps\f38\fs19\insrsid2571054 Disclaimer of Warranty.}{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0 \b\f38\fs19\insrsid2571054    }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 THE SOFTWARE IS LICENSED \'93AS-IS.\'94
  YOU BEAR THE RISK OF USING IT.  MICROSOFT GIVES NO EXPRESS WARRANTIES, GUARANTEES OR CONDITIONS.  YOU
MAY HAVE ADDITIONAL CONSUMER RIGHTS UNDER YOUR LOCAL LAWS WHICH THIS AGREEMENT CANNOT CHANGE.  TO THE EXTENT PERMITTED UNDER YOUR LOCAL LAWS, MICROSOFT EXCLUDES THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEME
NT.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0 \b\caps\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \fi-360\li360\ri0\sb120\sa120\widctlpar\tx360\wrapdefault\faauto\rin0\lin360\itap0\pararsid2571054 {\rtlch\fcs1 \ab\af39\afs20 \ltrch\fcs0 \b\caps\f39\fs20\insrsid2571054 16.\tab }{\rtlch\fcs1 \ab\af38\afs19 \ltrch\fcs0
\b\caps\f38\fs19\insrsid2571054 Limitation on and Exclusion of Remedies and Damages.   }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
YOU CAN RECOVER FROM MICROSOFT AND ITS SUPPLIERS ONLY DIRECT DAMAGES UP TO U.S. $5.00.  YOU CANNOT RECOVER ANY OTHER DAMAGES, INCLUDING CONSEQUENTIAL, LOST PROFITS, SPECIAL, INDIRECT OR INCIDENTAL DAMAGES.}{\rtlch\fcs1 \ab\af0\afs19 \ltrch\fcs0
\b\caps\fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \li357\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin357\itap0\pararsid2571054 {\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054 This limitation applies to
\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\tx720\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
anything related to the software, services, content (including code) on third party Internet sites, or third party programs; and
\par }\pard \ltrpar\ql \fi-363\li720\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin720\itap0\pararsid2571054 {\rtlch\fcs1 \af3\afs19 \ltrch\fcs0 \f3\fs19\insrsid2571054 \'b7\tab }{\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
claims for breach of contract, breach of warranty, guarantee or condition, strict liability, negligence, or other tort to the extent permitted by applicable law.
\par }\pard \ltrpar\ql \li360\ri0\sb120\sa120\widctlpar\wrapdefault\faauto\rin0\lin360\itap0\pararsid2571054 {\rtlch\fcs1 \af38\afs19 \ltrch\fcs0 \f38\fs19\insrsid2571054
It also applies even if Microsoft knew or should have known about the possibility of the damages.  The above limitation or exclusion may not apply to you because your country may
 not allow the exclusion or limitation of incidental, consequential or other damages.}{\rtlch\fcs1 \af0\afs19 \ltrch\fcs0 \fs19\dbch\af0\insrsid2571054
\par }\pard \ltrpar\ql \li0\ri0\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0\pararsid2571054 {\rtlch\fcs1 \af0 \ltrch\fcs0 \insrsid1841690\charrsid2571054
\par }{\*\themedata 504b030414000600080000002100828abc13fa0000001c020000130000005b436f6e74656e745f54797065735d2e786d6cac91cb6ac3301045f785fe83d0b6d8
72ba28a5d8cea249777d2cd20f18e4b12d6a8f843409c9df77ecb850ba082d74231062ce997b55ae8fe3a00e1893f354e9555e6885647de3a8abf4fbee29bbd7
2a3150038327acf409935ed7d757e5ee14302999a654e99e393c18936c8f23a4dc072479697d1c81e51a3b13c07e4087e6b628ee8cf5c4489cf1c4d075f92a0b
44d7a07a83c82f308ac7b0a0f0fbf90c2480980b58abc733615aa2d210c2e02cb04430076a7ee833dfb6ce62e3ed7e14693e8317d8cd0433bf5c60f53fea2fe7
065bd80facb647e9e25c7fc421fd2ddb526b2e9373fed4bb902e182e97b7b461e6bfad3f010000ffff0300504b030414000600080000002100a5d6a7e7c00000
00360100000b0000005f72656c732f2e72656c73848fcf6ac3300c87ef85bd83d17d51d2c31825762fa590432fa37d00e1287f68221bdb1bebdb4fc7060abb08
84a4eff7a93dfeae8bf9e194e720169aaa06c3e2433fcb68e1763dbf7f82c985a4a725085b787086a37bdbb55fbc50d1a33ccd311ba548b63095120f88d94fbc
52ae4264d1c910d24a45db3462247fa791715fd71f989e19e0364cd3f51652d73760ae8fa8c9ffb3c330cc9e4fc17faf2ce545046e37944c69e462a1a82fe353
bd90a865aad41ed0b5b8f9d6fd010000ffff0300504b0304140006000800000021006b799616830000008a0000001c0000007468656d652f7468656d652f7468
656d654d616e616765722e786d6c0ccc4d0ac3201040e17da17790d93763bb284562b2cbaebbf600439c1a41c7a0d29fdbd7e5e38337cedf14d59b4b0d592c9c
070d8a65cd2e88b7f07c2ca71ba8da481cc52c6ce1c715e6e97818c9b48d13df49c873517d23d59085adb5dd20d6b52bd521ef2cdd5eb9246a3d8b4757e8d3f7
29e245eb2b260a0238fd010000ffff0300504b03041400060008000000210096b5ade296060000501b0000160000007468656d652f7468656d652f7468656d65
312e786d6cec594f6fdb3614bf0fd87720746f6327761a07758ad8b19b2d4d1bc46e871e698996d850a240d2497d1bdae38001c3ba618715d86d87615b8116d8
a5fb34d93a6c1dd0afb0475292c5585e9236d88aad3e2412f9e3fbff1e1fa9abd7eec70c1d1221294fda5efd72cd4324f1794093b0eddd1ef62fad79482a9c04
98f184b4bd2991deb58df7dfbb8ad755446282607d22d771db8b944ad79796a40fc3585ee62949606ecc458c15bc8a702910f808e8c66c69b9565b5d8a314d3c
94e018c8de1a8fa94fd05093f43672e23d06af89927ac06762a049136785c10607758d9053d965021d62d6f6804fc08f86e4bef210c352c144dbab999fb7b471
7509af678b985ab0b6b4ae6f7ed9ba6c4170b06c788a705430adf71bad2b5b057d03606a1ed7ebf5babd7a41cf00b0ef83a6569632cd467faddec9699640f671
9e76b7d6ac355c7c89feca9cccad4ea7d36c65b258a206641f1b73f8b5da6a6373d9c11b90c537e7f08dce66b7bbeae00dc8e257e7f0fd2badd5868b37a088d1
e4600ead1ddaef67d40bc898b3ed4af81ac0d76a197c86826828a24bb318f3442d8ab518dfe3a20f000d6458d104a9694ac6d88728eee2782428d60cf03ac1a5
193be4cbb921cd0b495fd054b5bd0f530c1931a3f7eaf9f7af9e3f45c70f9e1d3ff8e9f8e1c3e3073f5a42ceaa6d9c84e5552fbffdeccfc71fa33f9e7ef3f2d1
17d57859c6fffac327bffcfc793510d26726ce8b2f9ffcf6ecc98baf3efdfdbb4715f04d814765f890c644a29be408edf3181433567125272371be15c308d3f2
8acd249438c19a4b05fd9e8a1cf4cd296699771c393ac4b5e01d01e5a30a787d72cf1178108989a2159c77a2d801ee72ce3a5c545a6147f32a99793849c26ae6
6252c6ed637c58c5bb8b13c7bfbd490a75330f4b47f16e441c31f7184e140e494214d273fc80900aedee52ead87597fa824b3e56e82e451d4c2b4d32a423279a
668bb6690c7e9956e90cfe766cb37b077538abd27a8b1cba48c80acc2a841f12e698f13a9e281c57911ce298950d7e03aba84ac8c154f8655c4f2af074481847
bd804859b5e696007d4b4edfc150b12addbecba6b18b148a1e54d1bc81392f23b7f84137c2715a851dd0242a633f900710a218ed715505dfe56e86e877f0034e
16bafb0e258ebb4faf06b769e888340b103d3311da9750aa9d0a1cd3e4efca31a3508f6d0c5c5c398602f8e2ebc71591f5b616e24dd893aa3261fb44f95d843b
5974bb5c04f4edafb95b7892ec1108f3f98de75dc97d5772bdff7cc95d94cf672db4b3da0a6557f70db629362d72bcb0431e53c6066acac80d699a6409fb44d0
8741bdce9c0e4971624a2378cceaba830b05366b90e0ea23aaa241845368b0eb9e2612ca8c742851ca251ceccc70256d8d87265dd96361531f186c3d9058edf2
c00eafe8e1fc5c509031bb4d680e9f39a3154de0accc56ae644441edd76156d7429d995bdd88664a9dc3ad50197c38af1a0c16d684060441db02565e85f3b966
0d0713cc48a0ed6ef7dedc2dc60b17e92219e180643ed27acffba86e9c94c78ab90980d8a9f0913ee49d62b512b79626fb06dccee2a432bbc60276b9f7dec44b
7904cfbca4f3f6443ab2a49c9c2c41476dafd55c6e7ac8c769db1bc399161ee314bc2e75cf8759081743be1236ec4f4d6693e5336fb672c5dc24a8c33585b5fb
9cc24e1d4885545b58463634cc5416022cd19cacfccb4d30eb45296023fd35a458598360f8d7a4003bbaae25e331f155d9d9a5116d3bfb9a95523e51440ca2e0
088dd844ec6370bf0e55d027a012ae264c45d02f708fa6ad6da6dce29c255df9f6cae0ec38666984b372ab5334cf640b37795cc860de4ae2816e95b21be5ceaf
8a49f90b52a51cc6ff3355f47e0237052b81f6800fd7b802239daf6d8f0b1571a8426944fdbe80c6c1d40e8816b88b8569082ab84c36ff0539d4ff6dce591a26
ade1c0a7f669880485fd484582903d284b26fa4e2156cff62e4b9265844c4495c495a9157b440e091bea1ab8aaf7760f4510eaa69a6465c0e04ec69ffb9e65d0
28d44d4e39df9c1a52ecbd3607fee9cec7263328e5d661d3d0e4f62f44acd855ed7ab33cdf7bcb8ae889599bd5c8b3029895b6825696f6af29c239b75a5bb1e6
345e6ee6c28117e73586c1a2214ae1be07e93fb0ff51e133fb65426fa843be0fb515c187064d0cc206a2fa926d3c902e907670048d931db4c1a44959d366ad93
b65abe595f70a75bf03d616c2dd959fc7d4e6317cd99cbcec9c58b34766661c7d6766ca1a9c1b327531486c6f941c638c67cd22a7f75e2a37be0e82db8df9f30
254d30c1372581a1f51c983c80e4b71ccdd28dbf000000ffff0300504b0304140006000800000021000dd1909fb60000001b010000270000007468656d652f74
68656d652f5f72656c732f7468656d654d616e616765722e786d6c2e72656c73848f4d0ac2301484f78277086f6fd3ba109126dd88d0add40384e4350d363f24
51eced0dae2c082e8761be9969bb979dc9136332de3168aa1a083ae995719ac16db8ec8e4052164e89d93b64b060828e6f37ed1567914b284d262452282e3198
720e274a939cd08a54f980ae38a38f56e422a3a641c8bbd048f7757da0f19b017cc524bd62107bd5001996509affb3fd381a89672f1f165dfe514173d9850528
a2c6cce0239baa4c04ca5bbabac4df000000ffff0300504b01022d0014000600080000002100828abc13fa0000001c0200001300000000000000000000000000
000000005b436f6e74656e745f54797065735d2e786d6c504b01022d0014000600080000002100a5d6a7e7c0000000360100000b000000000000000000000000
002b0100005f72656c732f2e72656c73504b01022d00140006000800000021006b799616830000008a0000001c00000000000000000000000000140200007468
656d652f7468656d652f7468656d654d616e616765722e786d6c504b01022d001400060008000000210096b5ade296060000501b000016000000000000000000
00000000d10200007468656d652f7468656d652f7468656d65312e786d6c504b01022d00140006000800000021000dd1909fb60000001b010000270000000000
00000000000000009b0900007468656d652f7468656d652f5f72656c732f7468656d654d616e616765722e786d6c2e72656c73504b050600000000050005005d010000960a00000000}
{\*\colorschememapping 3c3f786d6c2076657273696f6e3d22312e302220656e636f64696e673d225554462d3822207374616e64616c6f6e653d22796573223f3e0d0a3c613a636c724d
617020786d6c6e733a613d22687474703a2f2f736368656d61732e6f70656e786d6c666f726d6174732e6f72672f64726177696e676d6c2f323030362f6d6169
6e22206267313d226c743122207478313d22646b3122206267323d226c743222207478323d22646b322220616363656e74313d22616363656e74312220616363
656e74323d22616363656e74322220616363656e74333d22616363656e74332220616363656e74343d22616363656e74342220616363656e74353d22616363656e74352220616363656e74363d22616363656e74362220686c696e6b3d22686c696e6b2220666f6c486c696e6b3d22666f6c486c696e6b222f3e}
{\*\latentstyles\lsdstimax267\lsdlockeddef0\lsdsemihiddendef1\lsdunhideuseddef1\lsdqformatdef0\lsdprioritydef99{\lsdlockedexcept \lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority0 \lsdlocked0 Normal;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority9 \lsdlocked0 heading 1;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 2;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 3;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 4;
\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 5;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 6;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 7;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 8;\lsdqformat1 \lsdpriority9 \lsdlocked0 heading 9;
\lsdpriority39 \lsdlocked0 toc 1;\lsdpriority39 \lsdlocked0 toc 2;\lsdpriority39 \lsdlocked0 toc 3;\lsdpriority39 \lsdlocked0 toc 4;\lsdpriority39 \lsdlocked0 toc 5;\lsdpriority39 \lsdlocked0 toc 6;\lsdpriority39 \lsdlocked0 toc 7;
\lsdpriority39 \lsdlocked0 toc 8;\lsdpriority39 \lsdlocked0 toc 9;\lsdqformat1 \lsdpriority35 \lsdlocked0 caption;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority10 \lsdlocked0 Title;\lsdpriority1 \lsdlocked0 Default Paragraph Font;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority11 \lsdlocked0 Subtitle;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority22 \lsdlocked0 Strong;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority20 \lsdlocked0 Emphasis;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority59 \lsdlocked0 Table Grid;\lsdunhideused0 \lsdlocked0 Placeholder Text;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority1 \lsdlocked0 No Spacing;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading;\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List;\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List;\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List;\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid;\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 1;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 1;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 1;\lsdunhideused0 \lsdlocked0 Revision;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority34 \lsdlocked0 List Paragraph;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority29 \lsdlocked0 Quote;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority30 \lsdlocked0 Intense Quote;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 1;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 1;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 1;\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 2;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 2;\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 3;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 3;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 3;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 3;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 3;\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 3;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 4;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 4;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 4;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 4;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 4;\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 5;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 5;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 5;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 5;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 5;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 5;\lsdsemihidden0 \lsdunhideused0 \lsdpriority60 \lsdlocked0 Light Shading Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority61 \lsdlocked0 Light List Accent 6;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority62 \lsdlocked0 Light Grid Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority63 \lsdlocked0 Medium Shading 1 Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority64 \lsdlocked0 Medium Shading 2 Accent 6;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority65 \lsdlocked0 Medium List 1 Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority66 \lsdlocked0 Medium List 2 Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority67 \lsdlocked0 Medium Grid 1 Accent 6;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority68 \lsdlocked0 Medium Grid 2 Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority69 \lsdlocked0 Medium Grid 3 Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority70 \lsdlocked0 Dark List Accent 6;
\lsdsemihidden0 \lsdunhideused0 \lsdpriority71 \lsdlocked0 Colorful Shading Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority72 \lsdlocked0 Colorful List Accent 6;\lsdsemihidden0 \lsdunhideused0 \lsdpriority73 \lsdlocked0 Colorful Grid Accent 6;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority19 \lsdlocked0 Subtle Emphasis;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority21 \lsdlocked0 Intense Emphasis;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority31 \lsdlocked0 Subtle Reference;\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority32 \lsdlocked0 Intense Reference;
\lsdsemihidden0 \lsdunhideused0 \lsdqformat1 \lsdpriority33 \lsdlocked0 Book Title;\lsdpriority37 \lsdlocked0 Bibliography;\lsdqformat1 \lsdpriority39 \lsdlocked0 TOC Heading;}}{\*\datastore 010500000200000018000000
4d73786d6c322e534158584d4c5265616465722e352e3000000000000000000000060000
d0cf11e0a1b11ae1000000000000000000000000000000003e000300feff090006000000000000000000000001000000010000000000000000100000feffffff00000000feffffff0000000000000000ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
fffffffffffffffffdfffffffeffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff
ffffffffffffffffffffffffffffffff52006f006f007400200045006e00740072007900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000016000500ffffffffffffffffffffffffec69d9888b8b3d4c859eaf6cd158be0f0000000000000000000000003023
a5fcded8c901feffffff00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffffffffffffffffffffffff00000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffffffffffffffffffffffff0000000000000000000000000000000000000000000000000000
000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffffffffffffffffffffffff000000000000000000000000000000000000000000000000
0000000000000000000000000000000000000000000000000105000000000000}}";

            #endregion RTFString

            LoadRTF(rtf, rtf_eula);
        }

        private static void LoadRTF(string rtf, RichTextBox richTextBox)
        {
            if (string.IsNullOrEmpty(rtf))
            {
                throw new ArgumentNullException();
            }

            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

            //Create a MemoryStream of the Rtf content

            using (MemoryStream rtfMemoryStream = new MemoryStream())
            {
                using (StreamWriter rtfStreamWriter = new StreamWriter(rtfMemoryStream))
                {
                    rtfStreamWriter.Write(rtf);
                    rtfStreamWriter.Flush();
                    rtfMemoryStream.Seek(0, SeekOrigin.Begin);

                    //Load the MemoryStream into TextRange ranging from start to end of RichTextBox.
                    textRange.Load(rtfMemoryStream, DataFormats.Rtf);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                SetupWindow.RenderBody(new HVCC.Setup.Installing());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Settings.IsStaticPresentation)
            {
                Window.GetWindow(this).Close();
            }
        }
    }
}