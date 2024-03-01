using Microsoft.FluentUI.AspNetCore.Components;

namespace Undersoft.SDK.Service.Application.GUI.View;

public static class ViewGraphic
{
    public static class Size20
    {
        public sealed class GitHub : Icon { public GitHub() : base("GitHub", IconVariant.Regular, IconSize.Size20, @"<path fill-rule=""evenodd"" clip-rule=""evenodd"" d=""M10.178 0C4.55 0 0 4.583 0 10.254c0 4.533 2.915 8.369 6.959 9.727 0.506 0.102 0.691 -0.221 0.691 -0.492 0 -0.238 -0.017 -1.053 -0.017 -1.901 -2.831 0.611 -3.421 -1.222 -3.421 -1.222 -0.455 -1.188 -1.129 -1.494 -1.129 -1.494 -0.927 -0.628 0.068 -0.628 0.068 -0.628 1.028 0.068 1.567 1.053 1.567 1.053 0.91 1.562 2.376 1.12 2.966 0.849 0.084 -0.662 0.354 -1.12 0.64 -1.375 -2.258 -0.238 -4.634 -1.12 -4.634 -5.059 0 -1.12 0.404 -2.037 1.045 -2.75 -0.101 -0.255 -0.455 -1.307 0.101 -2.716 0 0 0.859 -0.272 2.797 1.053a9.786 9.786 0 0 1 2.545 -0.34c0.859 0 1.735 0.119 2.544 0.34 1.938 -1.324 2.797 -1.053 2.797 -1.053 0.556 1.409 0.202 2.462 0.101 2.716 0.657 0.713 1.045 1.63 1.045 2.75 0 3.939 -2.376 4.804 -4.651 5.059 0.371 0.323 0.691 0.934 0.691 1.901 0 1.375 -0.017 2.479 -0.017 2.818 0 0.272 0.185 0.594 0.691 0.493 4.044 -1.358 6.959 -5.195 6.959 -9.727C20.356 4.583 15.789 0 10.178 0z""/>") { } }
    }

    public static class Logo
    {
        public sealed class Header : Icon { public Header() : base("Undersoft", IconVariant.Regular, IconSize.Custom, @"<svg width=""130.55"" height=""40"" version=""1.1"" viewBox=""0 0 34.542 10.583"" xmlns=""http://www.w3.org/2000/svg""><g transform=""translate(-22.975 -41.986)""><path d=""m47.208 50.982c-0.58877-0.14267-0.76544-0.27822-0.68704-0.52712 0.05117-0.16246 0.20493-0.17699 0.59238-0.05595 0.57912 0.18092 1.1767 0.14043 1.1767-0.07973 0-0.10841-0.14178-0.17154-0.66807-0.29748-1.1416-0.27319-1.4558-0.95986-0.61137-1.3362 0.81408-0.36284 2.3415 0.09091 1.639 0.48689l-0.14185 0.07995-0.26077-0.09448c-0.32668-0.11836-0.79134-0.10313-0.87337 0.02865-0.08066 0.12955-0.05011 0.14538 0.60842 0.31521 1.0523 0.27139 1.3534 0.6884 0.87189 1.2077-0.2458 0.26513-1.0958 0.40589-1.646 0.27258zm2.8018-0.04872c-0.54184-0.21991-0.79868-0.64179-0.76031-1.2489l0.05787-0.33966 0.11996-0.23437c0.35988-0.70311 1.5627-0.75115 2.1618-0.1947 0.83939 0.7796 0.28255 2.048-0.92387 2.1045l-0.38996-0.01128zm0.99971-0.60457c0.62213-0.4928-0.02107-1.5404-0.7042-1.1845-0.62234 0.32426-0.37723 1.3461 0.32569 1.3578l0.21041-0.0401zm5.0413 0.62426c-0.44034-0.19244-0.5458-0.40866-0.58106-1.1912l-0.02752-0.61064-0.26392-0.05414c-0.70784-0.14524-0.37717-0.55107-0.02225-0.56021 0.23349-0.0011 0.32954-0.02464 0.34103-0.23904 0.0286-0.5334 0.71048-0.55821 0.71048-0.0458 0 0.24748 0.07901 0.28566 0.59118 0.28566h0.46449l0.10556 0.10637c0.12973 0.13071 0.02512 0.30107 0.01046 0.31928l-0.0951 0.11834-0.49871 0.02799c-0.58422 0.03278-0.57603 0.02485-0.57708 0.55988-0.0014 0.73904 0.12521 0.87666 0.7569 0.82243 0.4548-0.03903 0.6421 0.08218 0.51033 0.33028-0.11255 0.2119-1.0437 0.29741-1.4248 0.13085zm-23.072-0.0198c-0.23558-0.07193-0.42008-0.22401-0.52631-0.43383l-0.06249-0.22771-0.04004-0.79824v-0.82345l0.11731-0.08279c0.14594-0.103 0.30639-0.10571 0.44002-0.0075l0.10246 0.07535 0.02667 0.80711 0.02667 0.8071c0.02805 0.12518 0.01845 0.09011 0.0558 0.1324 0.16144 0.1828 0.79622 0.0047 0.94332-0.20696l0.08237-0.1185v-1.4063l0.11731-0.08279c0.14912-0.10524 0.30244-0.10524 0.45156 0l0.11731 0.08279v1.0239c0 1.2314-0.12138 1.5063-0.53374 1.1958l-0.13474-0.07461-0.28896 0.11672c-0.32393 0.13084-0.65437 0.09478-0.89454 0.02145zm5.9038-0.0021c-1.4868-0.45108-0.73716-2.8218 0.76053-2.4051 0.26409 0.07347 0.30759 0.01112 0.30759-0.44094 0-0.54039 0.36284-0.82363 0.61319-0.47865l0.07299 0.10058v1.4746c0 1.7965-0.0063 1.8173-0.51375 1.6875l-0.21063-0.05386-0.24666 0.08437c-0.26455 0.0905-0.55069 0.10198-0.78326 0.03143zm0.80526-0.55921c0.21852-0.11385 0.26286-0.23021 0.26286-0.68976v-0.40479l-0.12956-0.13054c-0.25315-0.25507-0.78221-0.13892-0.94538 0.20755-0.31481 0.66845 0.21293 1.3297 0.81208 1.0175zm2.4006 0.56026c-1.3387-0.34678-1.3962-1.9918-0.08296-2.3768 0.84187-0.24683 1.6929 0.24153 1.6929 0.97148v0.22795l-0.01911 0.16676-0.21552-0.0011h-0.78166l-0.82219-0.0063-7e-3 0.08992c-8e-3 0.1045 0.12423 0.26921 0.33598 0.37954 0.15157 0.07898 0.39569 0.07513 1.0198-0.01604l0.21574-0.0057 0.10632 0.10412 0.0027 0.1462-0.11137 0.13388c-0.19722 0.23708-0.9092 0.29616-1.3337 0.18619zm0.87092-1.6439c0-0.14572-0.22607-0.27206-0.48639-0.27183-0.25091 8.2e-5 -0.63005 0.15509-0.63005 0.28336l-0.03646 0.10097 0.62507-0.01225h0.52784zm1.1919 1.6175-0.08342-0.13445v-1.0003c0-1.0787 0.01542-1.1461 0.277-1.2096l0.18418 0.0515 0.22634 0.24178s0.075 0.03209 0.37463-0.09911c0.55485-0.24295 1.2075-0.19301 1.2075 0.0924 0 0.22187-0.09024 0.27456-0.47241 0.27585-0.39555 0.0013-0.69229 0.11597-0.9089 0.35112l-0.1409 0.15296-0.01744 0.59579c-0.01901 0.64908-0.03916 0.69588-0.31956 0.74172l-0.13368 9e-3zm8.6786-0.02808-0.10557-0.10637v-1.5982l-0.13539-0.05187c-0.07447-0.02852-0.20036-0.05187-0.27975-0.05187-0.18374 0-0.27104-0.08847-0.27104-0.27468 0-0.17208 0.12451-0.25678 0.3792-0.25797 0.23104-0.0011 0.27378-0.03773 0.34978-0.30006 0.1333-0.46007 0.7154-0.75299 1.3733-0.69108 0.82721 0.07784 0.85103 0.53989 0.02783 0.53989l-0.41101 0.03556-0.13234 0.06788c-0.07517 0.03856-0.10656 0.15249-0.098 0.21274l0.0155 0.1093 0.39454 0.01586c0.82891 0.03335 0.83279 0.52279 0.0045 0.56588-0.50434 0.02623-0.4782-0.02337-0.4782 0.90751v0.81819l-0.11731 0.08279c-0.16165 0.11409-0.3898 0.10366-0.51608-0.02358zm-17.394-0.077362-0.12956-0.13054v-1.9726l0.10556-0.10637c0.13554-0.13656 0.26676-0.13466 0.44477 0.0064l0.1423 0.11278 0.34098-0.11278c0.43171-0.1428 0.69923-0.14252 1.0305 0.0011l0.26262 0.11384 0.14304 0.24515 0.14303 0.24516-0.01034 0.76636-0.01031 0.76636-0.08131 0.08192c-0.09965 0.10041-0.4121 0.10729-0.52653 0.01158l-0.08411-0.07032-2.7e-4 -0.6184c-2.71e-4 -0.94235-0.08109-1.1236-0.49978-1.1236-0.54463 0-0.65203 0.17264-0.67302 1.0818l-0.01455 0.62972-0.12461 0.10156c-0.16739 0.13642-0.30274 0.12786-0.4584-0.02899z"" style=""fill:#fff;stroke-width:.20025""/><path d=""m26.308 43.152v-0.70359l0.69405-5.06e-4 0.69114-6e-3v1.4137h-1.3852z"" style=""fill:#fff;stroke-width:.12313""/><path d=""m28.866 43.308v-1.3272l1.3321 0.0057 1.3518-4.5e-5 -0.0025 0.78882-0.0021 0.81322-0.52243 5.68e-4 -0.53625-0.0046-0.0058 0.53147-0.0058 0.52307h-0.79308l-0.81785 0.0047z"" style=""fill:#ffffff;stroke-width:.08255""/><path transform=""translate(22.975 41.986)"" d=""m-0.026737 4.8544v-2.5162h5.0328l-0.00577 1.1189-0.00578 1.1189-2.0374 0.01156v2.7829h-2.9838z"" style=""fill:#ffffff;stroke-width:.27378""/><path d=""m32.207 47.294-0.0059-0.64572-1.4349-0.02208-0.0057-1.3853-0.0057-1.3853h4.0844v4.0841h-2.6264z"" style=""fill:#fff;stroke-width:.93144""/>  <path d=""m26.193 49.72v-2.8351h5.6907v5.6701h-5.6907z"" style=""fill:#fff;stroke-width:1.0088""/></g></svg>") { } }

        public static class ImageBlack { public static string Source = "img/logo-black.png"; }

        public static class ImageWhite { public static string Source = "img/logo-white.png"; }
    }
}

