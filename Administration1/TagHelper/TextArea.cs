using Ganss.XSS;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.TagHelpers
{
  [HtmlTargetElement("Text-Area")]
  public class TextArea : TagHelper
  {
    public ModelExpression AspFor { get; set; }
    public string Id { get; set; }
    public string Placeholder { get; set; }
    public string LabelContent { get; set; }
    public string Col { get; set; }
    public bool Required { get; set; }
    public string ErrorMessage { get; set; }
    public string Name { get; set; }
    public object Value { get; set; }
    public string Rows { get; set; }
    public string Dir { get; set; }


    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      HtmlSanitizer htmlSanitizer = new HtmlSanitizer();
      string is_filled = "";
      string ReqSpan = Required ? "<span style='color:red'> * </span>" : "";
      if (AspFor != null)
      {
        Name = AspFor.Name;
        Value = AspFor.Model;
        is_filled = AspFor.Model != null ? "is-filled" : "";
      }
      output.TagName = "div";
      output.Content.SetHtmlContent(@$"
													<div class='form-group'>
														<label class='form-label'> {LabelContent} {ReqSpan} </label>
														<textarea rows='{Rows}' class='form-control text-right {is_filled}' id='{Id}' name='{Name}' dir='{Dir}' {Required} placeholder='{Placeholder}'>{htmlSanitizer.Sanitize(Value?.ToString())}</textarea>
														<div class='invalid-feedback'>
															{ErrorMessage}
														</div>
                          </div>
                      ");
      output.Attributes.Add("class", !string.IsNullOrEmpty(Col) ? Col : "col-md-6");
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
