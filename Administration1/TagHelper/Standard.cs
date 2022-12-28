using Application.Common.Resources;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;

namespace Web.TagHelpers
{
  [HtmlTargetElement("Standard")]
  public class Standard : TagHelper
  {

    public Standard()
    {
    }
    public ModelExpression AspForSortIndex { get; set; }
    public ModelExpression AspForActive { get; set; }
    public ModelExpression AspForFocus { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      int SortIndx = 0;
      string Focus = "";
      string Active = "";

      if (AspForActive != null)
        Active = (bool)AspForActive.Model ? "checked" : "";
      if (AspForFocus != null)
        Focus = (bool)AspForFocus.Model ? "checked" : "";
      if (AspForSortIndex != null)
        SortIndx = (int)AspForSortIndex.Model;


      output.TagName = "div";
      output.Content.SetHtmlContent(@$"<div class='col-md-12'> <div class='row'> <div class='col-md-3 col-sm-6'>
              <div class='form-group'>
                <label class='form-label'> {"SortIndex"} </label>
                <input min = '0' oninput = 'validity.valid||(value='');' type = 'number' name='SortIndex' value='{SortIndx}' class='form-control' id='sort'/>
              </div>
            </div>
            <div class='col-md-4 col-sm-6' style='padding-top:43px;'>
              <div class='row  form-group'>
								<div class='col-md-6 col-sm-6'>
                  <div class='row'>
                    <input type = 'checkbox' {Focus} data-val-required='The Focus field is required.'data-val='true' value='true' name='Focus'  class='form-check mt-1' id='defaultInline1' />
										&nbsp; 
										<label> {"Focus"} </label>                  
									</div>
                </div>
								<div class='col-md-6 col-sm-6'>
                   <div class='row'>
                    <input type = 'checkbox' {Active} data-val-required='The Active field is required.'data-val='true' value='true' name='Active'  class='form-check mt-1' id='defaultInline2' />
										&nbsp;										
										<label> {"Active"} </label>                   
									</div>
                </div>
              </div>
            </div></div></div>");

      output.Attributes.Add("class", "form-row");

      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
