using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Administration.TagHelpers
{
    [HtmlTargetElement("File-Upload")]
    public class FileUpload : TagHelper
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public FileUpload(
                        IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public string ID { get; set; }
        public string Extension { set; get; }
        public string Objectname { get; set; }
        public string ObjectID { get; set; }
        public string Property { get; set; }
        public string name { get; set; }
        public string Filename { get; set; }
        public string Controllername { get; set; }
        public string area { get; set; }
        public string Multiple { get; set; }
        public string labelContent { get; set; }
        public string Required { get; set; }
        public string col { get; set; }
        public string idattr { get; set; }
        public string ErrorMessage { get; set; }
        public string maxAllowedSize { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string ReqSpan = Required == "Required" ? "<span style='color:red'> * </span>" : "";
            output.TagName = "div";
            string path = $"/Upload/{Objectname}/{Property}/{ObjectID}/{Filename}";
            string RemoveFileLink =
            " <a  onclick='RemoveFile(this,\"" + name + "\")' id='RemoveBtn" + name + "' name='" + name + "' target='_blank' style='color: red;text-decoration: underline;font-size: 15px;'> حذف </a>";
            if (string.IsNullOrEmpty(maxAllowedSize))
            {
                maxAllowedSize = "1024";
            }
            if (!string.IsNullOrEmpty(Filename))
            {
                output.Content.SetHtmlContent(@$" 
                                        <div class='form-group'>  
                                          <label class='form-label d-block LabelFile' >{labelContent} {ReqSpan}</label>
                                          <input type = 'file' accept='{Extension}' id='{ID}'  name= '{name}' {Required}  {Multiple}  onchange='validateSize(this,{maxAllowedSize})' /> 
                                          <a href='{path}' target='_blank' id='ShowBtn{name}' style='color: red;text-decoration: underline;font-size: 15px;'> {"View"} </a>
                             
                                          <div class='invalid-feedback'>
                                            {ErrorMessage}
                                          </div>
                               <span style='padding: 20px;'>
                                                 {RemoveFileLink}
                                            </span>
                                        </div> 
                                        <div>  
                                          <p style='font-size: 14px'>أقصى حجم للملف {maxAllowedSize} ك.ب</p>
                                        </div>
                                        ");
            }
            else
            {
                output.Content.SetHtmlContent(@$" 
                                        <div class='form-group'>  
                                          <label class='form-label d-block' >{labelContent} {ReqSpan}</label>
                                          <input type = 'file' accept='{Extension}' id='{ID}' name= '{name}' {Required}  {Multiple}  onchange='validateSize(this,{maxAllowedSize})' /> 
                                            <div class='invalid-feedback'>
                                              {ErrorMessage}
                                            </div>
                                        </div> 
                                        <div>  
                                          <p style='font-size: 14px'>أقصى حجم للملف {maxAllowedSize} ك.ب</p>
                                        </div>
                                      ");
            }
            if (!string.IsNullOrEmpty(col))
                output.Attributes.Add("class", col);
            else
                output.Attributes.Add("class", "col-md-6");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
