using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.TagHelpers
{
    [HtmlTargetElement("Ck-Editor")]
    public class CKEditor : TagHelper
    {
        public ModelExpression AspFor { get; set; }
        public string id { get; set; }
        public string placeholder { get; set; }
        public string labelContent { get; set; }
        public string ErrorMessage { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string name = "";
            object value = "";
            if (AspFor != null)
            {
                name = AspFor.Name;
                value = AspFor.Model;
            }
            output.TagName = "div";
            output.Content.SetHtmlContent(@$"
                          <div> <label> {labelContent} </label> </div>
                          <div>
                          <textarea class='form-control text-right cke_rtl' id='{id}' name='{name}' placeholder='{placeholder}'> {value} </textarea>
                            <div class='invalid-feedback'>
                              {ErrorMessage}
                            </div>
                          <script>
                            CKEDITOR.replace('{id}');
                          </script>
                          </div>");
            output.Attributes.Add("class", "form-group col-md-12");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
