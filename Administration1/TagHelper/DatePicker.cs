using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.TagHelpers
{
    [HtmlTargetElement("Date-Picker")]
    public class DatePicker : TagHelper
    {
        public ModelExpression AspFor { get; set; }
        public string id { get; set; }
        public string placeholder { get; set; }
        public string labelContent { get; set; }
        public string col { get; set; }
        public string Required { get; set; }
        public string ErrorMessage { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string name = "";
            string value = "";
            string is_filled = "";
            string ReqSpan = Required == "Required" ? "<span style='color:red'> * </span>" : "";
            if (AspFor != null)
            {
                name = AspFor.Name;
                value = AspFor.Model == null ? "" : ((DateTime)AspFor.Model).ToString("yyyy/MM/dd");
                is_filled = AspFor.Model != null ? "is-filled" : "";
            }
            output.TagName = "div";
            output.Content.SetHtmlContent(@$"<div class='form-group col-md-12'>
                          <label class='form-label'> {labelContent} {ReqSpan}</label>
                          <div class='input-group input-append date datepicker-container'>
                              <input type='text' class='form-control custom-datepicker' id='{id}' name='{name}' {Required} placeholder='{placeholder}' value='{value}' autocomplete='off'>
                              <div class='input-group-append'>
                                  <span class='border-bottom-right-radius-0 border-top-right-radius-0 input-group-text fs-xl'>
                                      <i class='fas fa-calendar'></i>
                                  </span>
                              </div>
                              <div class='invalid-feedback'>
                            {ErrorMessage}
                          </div>
                          </div>
                      </div>
                      ");
            if (!string.IsNullOrEmpty(col))
                output.Attributes.Add("class", col);
            else
                output.Attributes.Add("class", "col-md-6");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
