using Application;
using Application.Common.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;

namespace WEb.TagHelpers
{
  [HtmlTargetElement("Dropdown")]
  public class Dropdown : TagHelper
  {
    public ModelExpression AspFor { get; set; }
    [HtmlAttributeName("asp-items")]
    public SelectList l { get; set; }
    public string labelContent { get; set; }
    public string Required { get; set; }
    public string Disabled { get; set; }
    public string col { get; set; }
    public string name { get; set; }
    public string id { get; set; }
    public string ErrorMessage { get; set; }
    public bool DisableEmptySelection { get; set; }

    private readonly IHtmlGenerator _HtmlGenerator;

    public Dropdown(IHtmlGenerator htmlGenerator)
    {
      _HtmlGenerator = htmlGenerator;
    }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      string ReqSpan = !string.IsNullOrEmpty(Required) && Required.ToLower() == "required" ? "<span style='color:red'> * </span>" : "";
      string DisabledAttribute = !string.IsNullOrEmpty(Disabled) && Disabled.ToLower() == "disabled" ? "disabled" : "";
      string Options = DisableEmptySelection ? "" : $"<option value=''>{"Select"}</option>";
      string option = "";
      string DataValueRequired = AspFor != null ? $"the {AspFor.Name} field is required." : "";
      string iname = AspFor != null ? AspFor?.Name : name;
      string ID = AspFor != null ? AspFor?.Name : id;
      string ModelValue = AspFor != null ? AspFor.Model?.ToString() : "";
      foreach (SelectListItem item in l)
      {
        if (ModelValue == item.Value || item.Selected)
          option = $"<option selected='selected' value={item.Value}>{item.Text}</option>";
        else
          option = $"<option value={item.Value}>{item.Text}</option>";
        Options += option;
      }

      output.TagName = "div";
      output.Content.SetHtmlContent(@$"<div class='form-group'>
                                       <label class='form-label'>{labelContent} {ReqSpan}</label>
                                      <select {DisabledAttribute?.ToLower()} {Required?.ToLower()} class='select2 custom-select form-control' data-val='true'  data-val-required='{DataValueRequired}' id='{id}' name='{ID}'>
                                       {Options}
                                      </select>
                                        <div class='invalid-feedback'>
                                          {ErrorMessage}
                                        </div>
                                      </div>");
      if (!string.IsNullOrEmpty(col))
        output.Attributes.Add("class", col);
      else
        output.Attributes.Add("class", "col-md-6");
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
