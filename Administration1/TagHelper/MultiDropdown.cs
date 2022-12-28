using Application;
using Application.Common.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;

namespace Web.TagHelpers
{
  [HtmlTargetElement("MultiDropdown")]
  public class MultiDropdown : TagHelper
  {
    public ModelExpression AspFor { get; set; }
    [HtmlAttributeName("asp-items")]
    public MultiSelectList multiSelectList { get; set; }
    public string labelContent { get; set; }
    public string Required { get; set; }
    public string col { get; set; }
    public string name { get; set; }
    public string id { get; set; }
    public string ErrorMessage { get; set; }
    public bool DisableEmptySelection { get; set; }

    private readonly IHtmlGenerator _HtmlGenerator;
    public MultiDropdown(IHtmlGenerator htmlGenerator)
    {
      _HtmlGenerator = htmlGenerator;
    }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      string ReqSpan = Required == "Required" ? "<span style='color:red'> * </span>" : "";
      string Options ="";
      string DataValueRequired = AspFor != null ? $"the {AspFor.Name} field is required." : "";
      string ID = AspFor != null ? AspFor?.Name : id;
      string ModelValue = AspFor != null ? AspFor.Model.ToString() : "";

      string option;
      foreach (SelectListItem item in multiSelectList)
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
                                      <select class='select2 custom-select form-control' data-val='true' {Required} data-val-required='{DataValueRequired}' id='{id}' name='{ID}' multiple>
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
