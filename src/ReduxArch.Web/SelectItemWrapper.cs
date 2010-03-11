using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ReduxArch.Data;

namespace ReduxArch.Web
{
    public class SelectItemWrapper : List<SelectListItem>
    {
        public SelectItemWrapper(IEnumerable<SelectItem> modelState)
        {
            foreach (var item in modelState)
            {
                Add(new SelectListItem
                             {
                                 Text = item.Text,
                                 Selected = item.Selected,
                                 Value = item.Value
                             });
            }
        }

        public List<SelectListItem> FirstSelectListItem(string text)
        {
            Insert(0, new SelectListItem
                          {
                              Selected = false,
                              Text = text,
                              Value = string.Empty
                          });

            return this;
        }
    }
}