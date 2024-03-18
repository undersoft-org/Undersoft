using Microsoft.FluentUI.AspNetCore.Components;

namespace Undersoft.SDK.Service.Application.GUI.View;

public static class ViewGraphic
{
    public static class Size20
    {
        public sealed class GitHub : Icon
        {
            public GitHub()
                : base(
                    "GitHub",
                    IconVariant.Regular,
                    IconSize.Size20,
                    @"<path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""M10.178 0C4.55 0 0 4.583 0 10.254c0 4.533 2.915 8.369 6.959 9.727 0.506 0.102 0.691 -0.221 0.691 -0.492 0 -0.238 -0.017 -1.053 -0.017 -1.901 -2.831 0.611 -3.421 -1.222 -3.421 -1.222 -0.455 -1.188 -1.129 -1.494 -1.129 -1.494 -0.927 -0.628 0.068 -0.628 0.068 -0.628 1.028 0.068 1.567 1.053 1.567 1.053 0.91 1.562 2.376 1.12 2.966 0.849 0.084 -0.662 0.354 -1.12 0.64 -1.375 -2.258 -0.238 -4.634 -1.12 -4.634 -5.059 0 -1.12 0.404 -2.037 1.045 -2.75 -0.101 -0.255 -0.455 -1.307 0.101 -2.716 0 0 0.859 -0.272 2.797 1.053a9.786 9.786 0 0 1 2.545 -0.34c0.859 0 1.735 0.119 2.544 0.34 1.938 -1.324 2.797 -1.053 2.797 -1.053 0.556 1.409 0.202 2.462 0.101 2.716 0.657 0.713 1.045 1.63 1.045 2.75 0 3.939 -2.376 4.804 -4.651 5.059 0.371 0.323 0.691 0.934 0.691 1.901 0 1.375 -0.017 2.479 -0.017 2.818 0 0.272 0.185 0.594 0.691 0.493 4.044 -1.358 6.959 -5.195 6.959 -9.727C20.356 4.583 15.789 0 10.178 0z""/>"
                )
            { }
        }
    }

    public static class Logo
    {
        public sealed class MonoHorizontal130x40 : Icon
        {
            public MonoHorizontal130x40()
                : base(
                    "Undersoft",
                    IconVariant.Regular,
                    IconSize.Custom,
                    @"<svg width=""130.55"" height=""40"" version=""1.1"" viewBox=""0 0 34.542 10.583"" xmlns=""http://www.w3.org/2000/svg""> <g transform=""translate(-22.975 -41.986)"">
                                                                                                                        <path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""m47.208 50.982c-0.58877-0.14267-0.76544-0.27822-0.68704-0.52712 0.05117-0.16246 0.20493-0.17699 0.59238-0.05595 0.57912 0.18092 1.1767 0.14043 1.1767-0.07973 0-0.10841-0.14178-0.17154-0.66807-0.29748-1.1416-0.27319-1.4558-0.95986-0.61137-1.3362 0.81408-0.36284 2.3415 0.09091 1.639 0.48689l-0.14185 0.07995-0.26077-0.09448c-0.32668-0.11836-0.79134-0.10313-0.87337 0.02865-0.08066 0.12955-0.05011 0.14538 0.60842 0.31521 1.0523 0.27139 1.3534 0.6884 0.87189 1.2077-0.2458 0.26513-1.0958 0.40589-1.646 0.27258zm2.8018-0.04872c-0.54184-0.21991-0.79868-0.64179-0.76031-1.2489l0.05787-0.33966 0.11996-0.23437c0.35988-0.70311 1.5627-0.75115 2.1618-0.1947 0.83939 0.7796 0.28255 2.048-0.92387 2.1045l-0.38996-0.01128zm0.99971-0.60457c0.62213-0.4928-0.02107-1.5404-0.7042-1.1845-0.62234 0.32426-0.37723 1.3461 0.32569 1.3578l0.21041-0.0401zm5.0413 0.62426c-0.44034-0.19244-0.5458-0.40866-0.58106-1.1912l-0.02752-0.61064-0.26392-0.05414c-0.70784-0.14524-0.37717-0.55107-0.02225-0.56021 0.23349-0.0011 0.32954-0.02464 0.34103-0.23904 0.0286-0.5334 0.71048-0.55821 0.71048-0.0458 0 0.24748 0.07901 0.28566 0.59118 0.28566h0.46449l0.10556 0.10637c0.12973 0.13071 0.02512 0.30107 0.01046 0.31928l-0.0951 0.11834-0.49871 0.02799c-0.58422 0.03278-0.57603 0.02485-0.57708 0.55988-0.0014 0.73904 0.12521 0.87666 0.7569 0.82243 0.4548-0.03903 0.6421 0.08218 0.51033 0.33028-0.11255 0.2119-1.0437 0.29741-1.4248 0.13085zm-23.072-0.0198c-0.23558-0.07193-0.42008-0.22401-0.52631-0.43383l-0.06249-0.22771-0.04004-0.79824v-0.82345l0.11731-0.08279c0.14594-0.103 0.30639-0.10571 0.44002-0.0075l0.10246 0.07535 0.02667 0.80711 0.02667 0.8071c0.02805 0.12518 0.01845 0.09011 0.0558 0.1324 0.16144 0.1828 0.79622 0.0047 0.94332-0.20696l0.08237-0.1185v-1.4063l0.11731-0.08279c0.14912-0.10524 0.30244-0.10524 0.45156 0l0.11731 0.08279v1.0239c0 1.2314-0.12138 1.5063-0.53374 1.1958l-0.13474-0.07461-0.28896 0.11672c-0.32393 0.13084-0.65437 0.09478-0.89454 0.02145zm5.9038-0.0021c-1.4868-0.45108-0.73716-2.8218 0.76053-2.4051 0.26409 0.07347 0.30759 0.01112 0.30759-0.44094 0-0.54039 0.36284-0.82363 0.61319-0.47865l0.07299 0.10058v1.4746c0 1.7965-0.0063 1.8173-0.51375 1.6875l-0.21063-0.05386-0.24666 0.08437c-0.26455 0.0905-0.55069 0.10198-0.78326 0.03143zm0.80526-0.55921c0.21852-0.11385 0.26286-0.23021 0.26286-0.68976v-0.40479l-0.12956-0.13054c-0.25315-0.25507-0.78221-0.13892-0.94538 0.20755-0.31481 0.66845 0.21293 1.3297 0.81208 1.0175zm2.4006 0.56026c-1.3387-0.34678-1.3962-1.9918-0.08296-2.3768 0.84187-0.24683 1.6929 0.24153 1.6929 0.97148v0.22795l-0.01911 0.16676-0.21552-0.0011h-0.78166l-0.82219-0.0063-7e-3 0.08992c-8e-3 0.1045 0.12423 0.26921 0.33598 0.37954 0.15157 0.07898 0.39569 0.07513 1.0198-0.01604l0.21574-0.0057 0.10632 0.10412 0.0027 0.1462-0.11137 0.13388c-0.19722 0.23708-0.9092 0.29616-1.3337 0.18619zm0.87092-1.6439c0-0.14572-0.22607-0.27206-0.48639-0.27183-0.25091 8.2e-5 -0.63005 0.15509-0.63005 0.28336l-0.03646 0.10097 0.62507-0.01225h0.52784zm1.1919 1.6175-0.08342-0.13445v-1.0003c0-1.0787 0.01542-1.1461 0.277-1.2096l0.18418 0.0515 0.22634 0.24178s0.075 0.03209 0.37463-0.09911c0.55485-0.24295 1.2075-0.19301 1.2075 0.0924 0 0.22187-0.09024 0.27456-0.47241 0.27585-0.39555 0.0013-0.69229 0.11597-0.9089 0.35112l-0.1409 0.15296-0.01744 0.59579c-0.01901 0.64908-0.03916 0.69588-0.31956 0.74172l-0.13368 9e-3zm8.6786-0.02808-0.10557-0.10637v-1.5982l-0.13539-0.05187c-0.07447-0.02852-0.20036-0.05187-0.27975-0.05187-0.18374 0-0.27104-0.08847-0.27104-0.27468 0-0.17208 0.12451-0.25678 0.3792-0.25797 0.23104-0.0011 0.27378-0.03773 0.34978-0.30006 0.1333-0.46007 0.7154-0.75299 1.3733-0.69108 0.82721 0.07784 0.85103 0.53989 0.02783 0.53989l-0.41101 0.03556-0.13234 0.06788c-0.07517 0.03856-0.10656 0.15249-0.098 0.21274l0.0155 0.1093 0.39454 0.01586c0.82891 0.03335 0.83279 0.52279 0.0045 0.56588-0.50434 0.02623-0.4782-0.02337-0.4782 0.90751v0.81819l-0.11731 0.08279c-0.16165 0.11409-0.3898 0.10366-0.51608-0.02358zm-17.394-0.077362-0.12956-0.13054v-1.9726l0.10556-0.10637c0.13554-0.13656 0.26676-0.13466 0.44477 0.0064l0.1423 0.11278 0.34098-0.11278c0.43171-0.1428 0.69923-0.14252 1.0305 0.0011l0.26262 0.11384 0.14304 0.24515 0.14303 0.24516-0.01034 0.76636-0.01031 0.76636-0.08131 0.08192c-0.09965 0.10041-0.4121 0.10729-0.52653 0.01158l-0.08411-0.07032-2.7e-4 -0.6184c-2.71e-4 -0.94235-0.08109-1.1236-0.49978-1.1236-0.54463 0-0.65203 0.17264-0.67302 1.0818l-0.01455 0.62972-0.12461 0.10156c-0.16739 0.13642-0.30274 0.12786-0.4584-0.02899z"" />
                                                                                                                        <path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""m26.308 43.152v-0.70359l0.69405-5.06e-4 0.69114-6e-3v1.4137h-1.3852z"" />
                                                                                                                        <path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""m28.866 43.308v-1.3272l1.3321 0.0057 1.3518-4.5e-5 -0.0025 0.78882-0.0021 0.81322-0.52243 5.68e-4 -0.53625-0.0046-0.0058 0.53147-0.0058 0.52307h-0.79308l-0.81785 0.0047z""/>
                                                                                                                        <path fill-rule=""evenodd"" clip-rule=""evenodd"" transform=""translate(22.975 41.986)"" d=""m-0.026737 4.8544v-2.5162h5.0328l-0.00577 1.1189-0.00578 1.1189-2.0374 0.01156v2.7829h-2.9838z"" />
                                                                                                                        <path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""m32.207 47.294-0.0059-0.64572-1.4349-0.02208-0.0057-1.3853-0.0057-1.3853h4.0844v4.0841h-2.6264z"" />
                                                                                                                        <path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""m26.193 49.72v-2.8351h5.6907v5.6701h-5.6907z"" />
                                                                                                                        </g>
                                                                                                                        </svg>"
                )
            { }
        }

        public sealed class ColorHorizontal130x40 : Icon
        {
            public ColorHorizontal130x40()
                : base(
                    "Undersoft",
                    IconVariant.Regular,
                    IconSize.Custom,
                    @"<svg width=""130.55"" height=""40"" version=""1.1"" viewBox=""0 0 34.542 10.583"" xmlns=""http://www.w3.org/2000/svg""> <g transform=""translate(-22.975 -41.986)"">
                                                                                                                        <path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""m47.208 50.982c-0.58877-0.14267-0.76544-0.27822-0.68704-0.52712 0.05117-0.16246 0.20493-0.17699 0.59238-0.05595 0.57912 0.18092 1.1767 0.14043 1.1767-0.07973 0-0.10841-0.14178-0.17154-0.66807-0.29748-1.1416-0.27319-1.4558-0.95986-0.61137-1.3362 0.81408-0.36284 2.3415 0.09091 1.639 0.48689l-0.14185 0.07995-0.26077-0.09448c-0.32668-0.11836-0.79134-0.10313-0.87337 0.02865-0.08066 0.12955-0.05011 0.14538 0.60842 0.31521 1.0523 0.27139 1.3534 0.6884 0.87189 1.2077-0.2458 0.26513-1.0958 0.40589-1.646 0.27258zm2.8018-0.04872c-0.54184-0.21991-0.79868-0.64179-0.76031-1.2489l0.05787-0.33966 0.11996-0.23437c0.35988-0.70311 1.5627-0.75115 2.1618-0.1947 0.83939 0.7796 0.28255 2.048-0.92387 2.1045l-0.38996-0.01128zm0.99971-0.60457c0.62213-0.4928-0.02107-1.5404-0.7042-1.1845-0.62234 0.32426-0.37723 1.3461 0.32569 1.3578l0.21041-0.0401zm5.0413 0.62426c-0.44034-0.19244-0.5458-0.40866-0.58106-1.1912l-0.02752-0.61064-0.26392-0.05414c-0.70784-0.14524-0.37717-0.55107-0.02225-0.56021 0.23349-0.0011 0.32954-0.02464 0.34103-0.23904 0.0286-0.5334 0.71048-0.55821 0.71048-0.0458 0 0.24748 0.07901 0.28566 0.59118 0.28566h0.46449l0.10556 0.10637c0.12973 0.13071 0.02512 0.30107 0.01046 0.31928l-0.0951 0.11834-0.49871 0.02799c-0.58422 0.03278-0.57603 0.02485-0.57708 0.55988-0.0014 0.73904 0.12521 0.87666 0.7569 0.82243 0.4548-0.03903 0.6421 0.08218 0.51033 0.33028-0.11255 0.2119-1.0437 0.29741-1.4248 0.13085zm-23.072-0.0198c-0.23558-0.07193-0.42008-0.22401-0.52631-0.43383l-0.06249-0.22771-0.04004-0.79824v-0.82345l0.11731-0.08279c0.14594-0.103 0.30639-0.10571 0.44002-0.0075l0.10246 0.07535 0.02667 0.80711 0.02667 0.8071c0.02805 0.12518 0.01845 0.09011 0.0558 0.1324 0.16144 0.1828 0.79622 0.0047 0.94332-0.20696l0.08237-0.1185v-1.4063l0.11731-0.08279c0.14912-0.10524 0.30244-0.10524 0.45156 0l0.11731 0.08279v1.0239c0 1.2314-0.12138 1.5063-0.53374 1.1958l-0.13474-0.07461-0.28896 0.11672c-0.32393 0.13084-0.65437 0.09478-0.89454 0.02145zm5.9038-0.0021c-1.4868-0.45108-0.73716-2.8218 0.76053-2.4051 0.26409 0.07347 0.30759 0.01112 0.30759-0.44094 0-0.54039 0.36284-0.82363 0.61319-0.47865l0.07299 0.10058v1.4746c0 1.7965-0.0063 1.8173-0.51375 1.6875l-0.21063-0.05386-0.24666 0.08437c-0.26455 0.0905-0.55069 0.10198-0.78326 0.03143zm0.80526-0.55921c0.21852-0.11385 0.26286-0.23021 0.26286-0.68976v-0.40479l-0.12956-0.13054c-0.25315-0.25507-0.78221-0.13892-0.94538 0.20755-0.31481 0.66845 0.21293 1.3297 0.81208 1.0175zm2.4006 0.56026c-1.3387-0.34678-1.3962-1.9918-0.08296-2.3768 0.84187-0.24683 1.6929 0.24153 1.6929 0.97148v0.22795l-0.01911 0.16676-0.21552-0.0011h-0.78166l-0.82219-0.0063-7e-3 0.08992c-8e-3 0.1045 0.12423 0.26921 0.33598 0.37954 0.15157 0.07898 0.39569 0.07513 1.0198-0.01604l0.21574-0.0057 0.10632 0.10412 0.0027 0.1462-0.11137 0.13388c-0.19722 0.23708-0.9092 0.29616-1.3337 0.18619zm0.87092-1.6439c0-0.14572-0.22607-0.27206-0.48639-0.27183-0.25091 8.2e-5 -0.63005 0.15509-0.63005 0.28336l-0.03646 0.10097 0.62507-0.01225h0.52784zm1.1919 1.6175-0.08342-0.13445v-1.0003c0-1.0787 0.01542-1.1461 0.277-1.2096l0.18418 0.0515 0.22634 0.24178s0.075 0.03209 0.37463-0.09911c0.55485-0.24295 1.2075-0.19301 1.2075 0.0924 0 0.22187-0.09024 0.27456-0.47241 0.27585-0.39555 0.0013-0.69229 0.11597-0.9089 0.35112l-0.1409 0.15296-0.01744 0.59579c-0.01901 0.64908-0.03916 0.69588-0.31956 0.74172l-0.13368 9e-3zm8.6786-0.02808-0.10557-0.10637v-1.5982l-0.13539-0.05187c-0.07447-0.02852-0.20036-0.05187-0.27975-0.05187-0.18374 0-0.27104-0.08847-0.27104-0.27468 0-0.17208 0.12451-0.25678 0.3792-0.25797 0.23104-0.0011 0.27378-0.03773 0.34978-0.30006 0.1333-0.46007 0.7154-0.75299 1.3733-0.69108 0.82721 0.07784 0.85103 0.53989 0.02783 0.53989l-0.41101 0.03556-0.13234 0.06788c-0.07517 0.03856-0.10656 0.15249-0.098 0.21274l0.0155 0.1093 0.39454 0.01586c0.82891 0.03335 0.83279 0.52279 0.0045 0.56588-0.50434 0.02623-0.4782-0.02337-0.4782 0.90751v0.81819l-0.11731 0.08279c-0.16165 0.11409-0.3898 0.10366-0.51608-0.02358zm-17.394-0.077362-0.12956-0.13054v-1.9726l0.10556-0.10637c0.13554-0.13656 0.26676-0.13466 0.44477 0.0064l0.1423 0.11278 0.34098-0.11278c0.43171-0.1428 0.69923-0.14252 1.0305 0.0011l0.26262 0.11384 0.14304 0.24515 0.14303 0.24516-0.01034 0.76636-0.01031 0.76636-0.08131 0.08192c-0.09965 0.10041-0.4121 0.10729-0.52653 0.01158l-0.08411-0.07032-2.7e-4 -0.6184c-2.71e-4 -0.94235-0.08109-1.1236-0.49978-1.1236-0.54463 0-0.65203 0.17264-0.67302 1.0818l-0.01455 0.62972-0.12461 0.10156c-0.16739 0.13642-0.30274 0.12786-0.4584-0.02899z"" />
                                                                                                                        <path d=""m26.308 43.152v-0.70359l0.69405-5.06e-4 0.69114-6e-3v1.4137h-1.3852z"" style=""fill:#fc3;stroke-width:.093248""/>
                                                                                                                        <path d=""m28.866 43.308v-1.3272l1.3321 0.0057 1.3518-4.5e-5 -0.0025 0.78882-0.0021 0.81322-0.52243 5.68e-4 -0.53625-0.0046-0.0058 0.53147-0.0058 0.52307h-0.79308l-0.81785 0.0047z"" style=""fill:#3c3;stroke-width:.062516""/>
                                                                                                                        <path transform=""translate(22.975 41.986)"" d=""m-0.026737 4.8544v-2.5162h5.0328l-0.00577 1.1189-0.00578 1.1189-2.0374 0.01156v2.7829h-2.9838z"" style=""fill:#90f;stroke-width:.73997"" />
                                                                                                                        <path d=""m32.207 47.294-0.0059-0.64572-1.4349-0.02208-0.0057-1.3853-0.0057-1.3853h4.0844v4.0841h-2.6264z"" style=""fill:#36f;stroke-width:.19787"" />
                                                                                                                        <path d=""m26.193 49.72v-2.8351h5.6907v5.6701h-5.6907z"" style=""fill:#f03;stroke-width:.76398""/>
                                                                                                                        </g>
                                                                                                                        </svg>"
                )
            { }
        }

        public sealed class ColorSquare260x230 : Icon
        {
            public ColorSquare260x230()
                : base(
                    "Undersoft",
                    IconVariant.Regular,
                    IconSize.Custom,
                    @"<svg width=""220"" height=""200"" version=""1.1"" viewBox=""0 0 68.542 60.949"" xmlns=""http://www.w3.org/2000/svg"">
                     <g transform=""matrix(5.109 0 0 5.109 -113.74 -231.65)"">
                      <path d=""m26.805 46.488v-0.52959l0.52884-3.81e-4 0.52662-0.0046v1.0641h-1.0555z"" style=""fill:#fc3;stroke-width:.093248""/>
                      <path d=""m28.815 46.517v-0.99899l1.015 0.0043 1.03-3.4e-5 -0.0019 0.59375-0.0016 0.61211-0.39807 4.28e-4 -0.4086-0.0035-0.0043 0.40004-0.0043 0.39372h-0.6043l-0.62317 0.0036z"" style=""fill:#3c3;stroke-width:.062516""/>
                      <path d=""m24.435 49.242v-1.8074h3.6596l-0.0082 1.6075-1.4815 0.0083v1.999h-2.1697z"" style=""fill:#36f;stroke-width:.19787""/>
                      <path d=""m31.357 49.611-0.0047-0.50986-1.1469-0.01743-9e-3 -2.1876h3.2647v3.2248h-2.0993z"" style=""fill:#90f;stroke-width:.73997""/>
                      <path d=""m30.126 55.393c-0.2989-0.06511-0.38859-0.12697-0.34878-0.24056 0.02597-0.07414 0.10404-0.08077 0.30073-0.02553 0.294 0.08256 0.59737 0.06408 0.59737-0.03639 0-0.04948-0.07197-0.07829-0.33916-0.13576-0.57955-0.12468-0.73906-0.43805-0.31037-0.6098 0.41328-0.16559 1.1887 0.0415 0.83206 0.2222l-0.07201 0.03648-0.13238-0.04312c-0.16584-0.05401-0.40173-0.04707-0.44338 0.01308-0.04095 0.05913-0.02545 0.06634 0.30887 0.14385 0.53422 0.12386 0.68707 0.31416 0.44263 0.55116-0.12478 0.121-0.5563 0.18524-0.83561 0.1244zm1.4224-0.02223c-0.27507-0.10036-0.40546-0.29289-0.38598-0.56996l0.02937-0.15501 0.0609-0.10696c0.1827-0.32088 0.79332-0.3428 1.0975-0.08885 0.42613 0.35579 0.14344 0.93465-0.46902 0.96043l-0.19797-0.0052zm0.50752-0.27591c0.31583-0.2249-0.0107-0.70299-0.3575-0.54057-0.31594 0.14798-0.19151 0.61432 0.16534 0.61966l0.10682-0.01829zm2.5593 0.28489c-0.22354-0.08782-0.27708-0.1865-0.29498-0.54363l-0.01397-0.27868-0.13398-0.02469c-0.35934-0.0663-0.19148-0.25149-0.01129-0.25566 0.11853-5.02e-4 0.1673-0.01124 0.17313-0.10909 0.01452-0.24343 0.36068-0.25475 0.36068-0.02091 0 0.11294 0.04011 0.13037 0.30012 0.13037h0.2358l0.05359 0.04854c0.06586 0.05965 0.01275 0.1374 0.0053 0.14571l-0.04827 0.05401-0.25318 0.01277c-0.29659 0.01496-0.29243 0.01134-0.29296 0.25551-7.1e-4 0.33728 0.06356 0.40008 0.38425 0.37533 0.23088-0.01782 0.32597 0.03751 0.25908 0.15073-0.05714 0.09671-0.52985 0.13573-0.72332 0.05971zm-11.713-0.0089c-0.1196-0.03283-0.21326-0.10223-0.26719-0.19799l-0.03172-0.10392-0.02032-0.36429v-0.37585l0.05956-0.03778c0.07408-0.04702 0.15554-0.04824 0.22338-0.0034l0.05202 0.0344 0.02708 0.73668c0.01424 0.05712 0.0093 0.04111 0.02832 0.06043 0.08196 0.08343 0.40421 2e-3 0.47889-0.09445l0.04181-0.05408v-0.64189l0.05955-0.03779c0.0757-0.04803 0.15354-0.04803 0.22924 0l0.05956 0.03779v0.46728c0 0.56197-0.06163 0.68743-0.27096 0.54573l-0.06841-0.03406-0.1467 0.05327c-0.16445 0.05972-0.3322 0.04325-0.45412 0.0098zm2.9971-0.0011c-0.75479-0.20586-0.37423-1.2878 0.38609-1.0976 0.13407 0.03353 0.15615 5e-3 0.15615-0.20123 0-0.24662 0.1842-0.37588 0.31129-0.21844l0.03705 0.04589v0.67296c0 0.81987-0.0032 0.82936-0.26081 0.77012l-0.10693-0.02457-0.12522 0.03851c-0.1343 0.04131-0.27957 0.04655-0.39763 0.01435zm0.4088-0.2552c0.11094-0.05196 0.13345-0.10506 0.13345-0.31479v-0.18474l-0.06577-0.05957c-0.12851-0.1164-0.3971-0.0634-0.47993 0.09472-0.15982 0.30506 0.1081 0.60684 0.41226 0.46436zm1.2187 0.25568c-0.67961-0.15826-0.7088-0.909-0.04212-1.0847 0.42739-0.11264 0.85942 0.11023 0.85942 0.44336v0.10408l-0.0097 0.07612-0.10941-5.04e-4h-0.39682l-0.4174-0.0029-0.0036 0.04104c-4e-3 0.04769 0.06306 0.12286 0.17056 0.17321 0.07695 0.03604 0.20088 0.03429 0.51772-0.0073l0.10952-0.0027 0.05397 0.04752 0.0014 0.06672-0.05654 0.06109c-0.10012 0.1082-0.46157 0.13516-0.67707 0.08498zm0.44213-0.75023c0-0.06649-0.11477-0.12416-0.24692-0.12406-0.12738 3.7e-5 -0.31985 0.07078-0.31985 0.12932l-0.01851 0.04608 0.31732-0.0055h0.26796zm0.60508 0.73818-0.04234-0.06135v-0.45652c0-0.49229 0.0078-0.52304 0.14062-0.55202l0.09349 0.0235 0.1149 0.11034s0.03808 0.01465 0.19018-0.04523c0.28168-0.11088 0.613-0.08808 0.613 0.04217 0 0.10125-0.04581 0.1253-0.23982 0.12589-0.20081 5.92e-4 -0.35145 0.05293-0.46142 0.16024l-0.07153 0.0698-0.0089 0.2719c-0.0097 0.29622-0.01988 0.31758-0.16223 0.3385l-0.06787 0.0041zm4.4058-0.01282-0.05359-0.04854v-0.72937l-0.06874-0.02367c-0.03781-0.01301-0.10172-0.02367-0.14202-0.02367-0.09328 0-0.1376-0.04038-0.1376-0.12536 0-0.07855 0.0632-0.11718 0.1925-0.11773 0.11729-5.03e-4 0.13899-0.01722 0.17757-0.13694 0.06767-0.20996 0.36318-0.34364 0.69717-0.31539 0.41994 0.03554 0.43204 0.24639 0.01413 0.24639l-0.20865 0.01623-0.06718 0.03098c-0.03817 0.0176-0.0541 0.06959-0.04974 0.09708l0.0079 0.04988 0.2003 0.0072c0.42081 0.01523 0.42278 0.23858 0.0022 0.25825-0.25604 0.01197-0.24276-0.01064-0.24276 0.41416v0.37337l-0.05955 0.03778c-0.08207 0.05206-0.19789 0.04731-0.262-0.01075zm-8.8303-0.0353-0.06577-0.05957v-0.90021l0.05358-0.04854c0.06881-0.06232 0.13542-0.06146 0.22579 0.0029l0.07223 0.05148 0.1731-0.05148c0.21916-0.06518 0.35497-0.06504 0.52315 5.03e-4l0.13332 0.05196 0.07262 0.11188 0.0726 0.11188-0.0053 0.34974-0.0053 0.34975-0.04129 0.03739c-0.05058 0.04582-0.20921 0.04897-0.2673 0.0053l-0.0427-0.03209-1.38e-4 -0.28222c-1.37e-4 -0.43006-0.04116-0.51278-0.25372-0.51278-0.27649 0-0.33101 0.07878-0.34167 0.4937l-0.0073 0.28739-0.06327 0.04635c-0.08497 0.06226-0.15369 0.05837-0.23271-0.01322z"" clip-rule=""evenodd"" fill-rule=""evenodd""/>
                      <path d=""m26.832 51.402v-2.134h4.3361v4.2679h-4.3361z"" style=""fill:#f03;stroke-width:.76398""/>
                      <text x=""30.97579"" y=""58.698082"" clip-rule=""evenodd"" fill-rule=""evenodd"" style=""font-family:sans-serif;font-size:4.8584px;letter-spacing:0px;line-height:125%;stroke-width:.12146px;word-spacing:0px"" xml:space=""preserve""><tspan style=""stroke-width:.12146px""/></text>
                     </g>
                     <text transform=""scale(1.1888 .84118)"" x=""0.83942997"" y=""69.360588"" fill-rule=""evenodd"" clip-rule=""evenodd"" style=""font-family:sans-serif;font-size:28.588px;letter-spacing:0px;line-height:125%;stroke-width:.71472px;word-spacing:0px"" xml:space=""preserve""><tspan x=""0.83942997"" y=""69.360588"" style=""font-family:'Cascadia Code';font-size:9.5292px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;font-variation-settings:'wght' 200;stroke-width:.71472px"">sophistics</tspan></text>
                    </svg>"
                )
            { }
        }
    }

    public static class Topic
    {
        public sealed class Benchmarks : Icon
        {
            public Benchmarks()
                : base(
                    "Benchmarks",
                    IconVariant.Regular,
                    IconSize.Custom,
                    @"<svg width=""240"" height=""40"" version=""1.1"" viewBox=""0 0 79.377 11.906"" xmlns=""http://www.w3.org/2000/svg"">
                    <g transform=""matrix(2.1784,0,0,2.1784,-45.901,-91.18)"">
                    <path d=""m21.071 44.606v-2.6709h5.0403v5.3414h-5.0403z"" style=""fill:#f03;stroke-width:.92145""/>
                    <text fill-rule=""evenodd"" clip-rule=""evenodd"" transform=""scale(.90811 1.1012)"" x=""25.777142"" y=""42.325024"" style=""font-family:sans-serif;font-size:14.862px;letter-spacing:0px;line-height:125%;stroke-width:.37158px;word-spacing:0px"" xml:space=""preserve""><tspan x=""25.777142"" y=""42.325024"" style=""font-family:'Cascadia Code';font-size:4.9542px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;font-variation-settings:'wght' 300;stroke-width:.37158px"">Benchmarks</tspan></text>
                    </g>
                    </svg>"
                )
            { }
        }

        public sealed class Documentation : Icon
        {
            public Documentation()
                : base(
                    "Documentation",
                    IconVariant.Regular,
                    IconSize.Custom,
                    @"<svg width=""240"" height=""40"" version=""1.1"" viewBox=""0 0 79.377 11.906"" xmlns=""http://www.w3.org/2000/svg"">
                    <g transform=""matrix(2.1784,0,0,2.1784,-45.901,-91.18)"">
                    <path d=""m21.071 44.606v-2.6709h5.0403v5.3414h-5.0403z"" style=""fill:#36f;stroke-width:.92145""/>
                    <text fill-rule=""evenodd"" clip-rule=""evenodd"" transform=""scale(.90811 1.1012)"" x=""25.777142"" y=""42.325024"" style=""font-family:sans-serif;font-size:14.862px;letter-spacing:0px;line-height:125%;stroke-width:.37158px;word-spacing:0px"" xml:space=""preserve""><tspan x=""25.777142"" y=""42.325024"" style=""font-family:'Cascadia Code';font-size:4.9542px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;font-variation-settings:'wght' 300;stroke-width:.37158px"">Documentation</tspan></text>
                    </g>
                    </svg>"
                )
            { }
        }

        public sealed class Downloads : Icon
        {
            public Downloads()
                : base(
                    "Downloads",
                    IconVariant.Regular,
                    IconSize.Custom,
                    @"<svg width=""240"" height=""40"" version=""1.1"" viewBox=""0 0 79.377 11.906"" xmlns=""http://www.w3.org/2000/svg"">
                    <g transform=""matrix(2.1784,0,0,2.1784,-45.901,-91.18)"">
                    <path d=""m21.071 44.606v-2.6709h5.0403v5.3414h-5.0403z"" style=""fill:#3c3;stroke-width:.92145""/>
                    <text fill-rule=""evenodd"" clip-rule=""evenodd"" transform=""scale(.90811 1.1012)"" x=""25.777142"" y=""42.325024"" style=""font-family:sans-serif;font-size:14.862px;letter-spacing:0px;line-height:125%;stroke-width:.37158px;word-spacing:0px"" xml:space=""preserve""><tspan x=""25.777142"" y=""42.325024"" style=""font-family:'Cascadia Code';font-size:4.9542px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;font-variation-settings:'wght' 300;stroke-width:.37158px"">Downloads</tspan></text>
                    </g>
                    </svg>"
                )
            { }
        }

        public sealed class Contact : Icon
        {
            public Contact()
                : base(
                    "Downloads",
                    IconVariant.Regular,
                    IconSize.Custom,
                    @"<svg width=""240"" height=""40"" version=""1.1"" viewBox=""0 0 79.377 11.906"" xmlns=""http://www.w3.org/2000/svg"">
                    <g transform=""matrix(2.1784,0,0,2.1784,-45.901,-91.18)"">
                    <path d=""m21.071 44.606v-2.6709h5.0403v5.3414h-5.0403z"" style=""fill:#ffcc33;stroke-width:.92145""/>
                    <text fill-rule=""evenodd"" clip-rule=""evenodd"" transform=""scale(.90811 1.1012)"" x=""25.777142"" y=""42.325024"" style=""font-family:sans-serif;font-size:14.862px;letter-spacing:0px;line-height:125%;stroke-width:.37158px;word-spacing:0px"" xml:space=""preserve""><tspan x=""25.777142"" y=""42.325024"" style=""font-family:'Cascadia Code';font-size:4.9542px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;font-variation-settings:'wght' 300;stroke-width:.37158px"">Contact</tspan></text>
                    </g>
                    </svg>"
                )
            { }
        }

        public sealed class TechAndTools : Icon
        {
            public TechAndTools()
                : base(
                    "Downloads",
                    IconVariant.Regular,
                    IconSize.Custom,
                    @"<svg width=""205"" height=""41"" version=""1.1"" viewBox=""0 0 54.24 10.848"" xmlns=""http://www.w3.org/2000/svg"">
                     <rect x=""20.71"" y=""1.3063"" width=""8.6342"" height=""8.6342"" style=""fill:#cf0;font-variation-settings:'wght' 300""/>
                     <text fill-rule=""evenodd"" clip-rule=""evenodd"" x=""0.61568415"" y=""8.0887651"" style=""font-family:Sans;font-size:11.33px;font-variation-settings:'wght' 300;letter-spacing:0px;line-height:125%;stroke-width:.31642px;;word-spacing:0px"" xml:space=""preserve""><tspan x=""0.61568415"" y=""8.0887651"" style=""font-family:'Cascadia Code';font-size:7.5941px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;font-variation-settings:'wght' 300;stroke-width:.31642px;stroke:none"">Tech &amp; Tools</tspan></text>
                    </svg>"
                )
            { }
        }

    }

    public static class Title
    {
        public sealed class Servitizone : Icon
        {
            public Servitizone()
                : base(
                    "Benchmarks",
                    IconVariant.Regular,
                    IconSize.Custom,
                    @"<svg width=""370"" height=""100"" version=""1.1"" viewBox=""0 0 109.8 22.224"" xmlns=""http://www.w3.org/2000/svg"">
                      <g transform=""matrix(2.4897 0 0 3.6725 -52.463 -153.78)"" style=""stroke-width:.99997"">
                       <path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""m51.179 46.488v-0.71333h14.01v1.4266h-14.01z"" style=""stroke-width:1.0906""/>
                       <path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""m51.077 46.737v-0.45904h5.9322v0.91806h-5.9322z"" style=""stroke-width:1.0906""/>
                       <rect x=""21.072"" y=""41.874"" width=""6.9495"" height=""4.9923"" style=""fill:#9900ff;font-variation-settings:'wght' 426;stroke-width:.9299""/>
                       <text fill-rule=""evenodd"" clip-rule=""evenodd"" transform=""scale(1.0673 .93692)"" x=""22.724001"" y=""49.438763"" style=""font-family:sans-serif;font-size:18.036px;letter-spacing:0px;line-height:125%;stroke-width:1.0906;word-spacing:0px"" xml:space=""preserve"">
                       <tspan fill-rule=""evenodd"" clip-rule=""evenodd"" x=""22.724001"" y=""49.438763"" style=""font-family:'Cascadia Code';font-size:6.0119px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;font-variation-settings:'wght' 426;stroke-width:1.0906"">Servitizone</tspan></text>
                       <text transform=""scale(1.2283 .81415)"" x=""41.360222"" y=""57.968552"" style=""fill:#9900ff;font-family:sans-serif;font-size:10.186px;letter-spacing:0px;line-height:125%;stroke-width:1.0906;word-spacing:0px"" xml:space=""preserve""><tspan x=""41.360222"" y=""57.968552"" style=""fill:#9900ff;font-family:'Cascadia Code';font-size:3.3954px;font-variant-caps:normal;font-variant-east-asian:normal;font-variant-ligatures:normal;font-variant-numeric:normal;font-variation-settings:'wght' 600;stroke-width:1.0906"">engine</tspan></text>
                      </g>
                     </svg>"
                )
            { }
        }
    }
}
