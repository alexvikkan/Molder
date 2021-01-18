﻿using Molder.Web.Models.PageObject.Attributes;
using Molder.Web.Models.PageObject.Models.Elements;
using Molder.Web.Models.PageObject.Models.Page;

namespace PageObject.Pages.SubPages
{
    [Page(Name = "Dropdown", Url = "http://192.168.99.100:7080/dropdown")]
    public class DropdownPage : Page
    {
        [Element(Name = "Dropdown List", Locator = "//*[@id=\"dropdown\"]")]
        Dropdown dropdownList;
    }
}