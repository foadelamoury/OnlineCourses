using Ganss.XSS;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.TagHelpers
{
  [HtmlTargetElement("Text-Box")]
  public class Textbox : TagHelper
  {
    public ModelExpression AspFor { get; set; }
    public string Id { get; set; }
    public string Placeholder { get; set; }
    public string LabelContent { get; set; }
    public string Type { get; set; }
    public string Step { get; set; }
    public string Col { get; set; }
    public string Required { get; set; }
    public string Disabled { get; set; }
    public string ErrorMessage { get; set; }
    public string Name { get; set; }
    public object Value { get; set; }
    public string pattern { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
    HtmlSanitizer htmlSanitizer = new HtmlSanitizer();
      string is_filled = "";
      string DisabledAttribute = !string.IsNullOrEmpty(Disabled) && Disabled.ToLower() == "disabled" ? "disabled" : "";
      string ReqSpan = Required == "Required" ? "<span style='color:red'> * </span>" : "";
      pattern = @"\S(.*)?";
      //pattern = @"^[a-zA-Z0-9].*";

      if (AspFor != null)
      {
        Name = AspFor.Name;
        Value = AspFor.Model;
        is_filled = AspFor.Model != null ? "is-filled" : "";
      }
      Step = !string.IsNullOrEmpty(Step) ? $"step='{Step}'" : "";
      output.TagName = "div";
      output.Content.SetHtmlContent(@$"<div class='form-group'>
                          <label class='form-label'> {LabelContent} {ReqSpan} </label>
                          <input {DisabledAttribute?.ToLower()} {Required?.ToLower()} type='{Type}' class='form-control text-right {is_filled}' id='{Id}' name='{Name}'  {Required} pattern='{pattern}'  placeholder='{Placeholder}' value='{htmlSanitizer.Sanitize(Value?.ToString())}' {Step}/>
                          <div class='invalid-feedback'>
                            {ErrorMessage}
                          </div>
                          </div>
                      ");
      if (!string.IsNullOrEmpty(Col))
        output.Attributes.Add("class", Col);
      else
        output.Attributes.Add("class", "col-md-6");

      output.TagMode = TagMode.StartTagAndEndTag;
    }

  }
}
