﻿using Implem.Pleasanter.Libraries.Html;
using Implem.Pleasanter.Libraries.Responses;
using Implem.Pleasanter.Libraries.Security;
namespace Implem.Pleasanter.Libraries.HtmlParts
{
    public static class HtmlHeaders
    {
        public static HtmlBuilder PageHeader(
            this HtmlBuilder hb,
            Permissions.Types permissionType,
            long siteId,
            string referenceType,
            bool useSearch,
            bool allowAccess,
            bool useNavigationMenu)
        {
            return hb.Header(css: "header", action: () => hb
                .H(number: 2, css: "logo", action: () => hb
                    .A(
                        attributes: new HtmlAttributes().Href(Navigations.Top()),
                        action: () => hb
                            .Img(
                                src: Navigations.Images("logo-corp.png"),
                                css: "logo-corp")
                            .Span(css: "logo-product", action: () => hb
                                .Displays_ProductName())))
                .Nav(id: "Navigations", action: () => hb
                    .NavigationMenu(
                        permissionType: permissionType,
                        siteId: siteId,
                        referenceType: referenceType,
                        allowAccess: allowAccess,
                        useNavigationMenu: useNavigationMenu)
                    .Search(_using: useSearch)));
        }

        private static HtmlBuilder Search(this HtmlBuilder hb, bool _using)
        {
            return _using
                ? hb
                    .Div(id: "SearchField", action: () => hb
                        .TextBox(
                            controlId: "Search",
                            controlCss: " w150 redirect",
                            placeholder: Displays.Search()))
                : hb;
        }
    }
}