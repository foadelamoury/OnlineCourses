

function ShowFormModal(ID, Url) {
  let urlPage = "";
  if (ID == 0) {
      urlPage = Url;
  } else {
      urlPage = Url + "/" + ID;
  }
    window.location.href = urlPage;
  
}



//var runDatePickerLimiting = function () {
//  $.fn.datepicker.dates['ar'] = {
//    days: ["أحد", "أثنين", "ثلاثاء", "أربعاء", "خميس", "جمعة", "سبت"],
//    daysShort: ["أحد", "أثنين", "ثلاثاء", "أربعاء", "خميس", "جمعة", "سبت"],
//    daysMin: ["أحد", "أثنين", "ثلاثاء", "أربعاء", "خميس", "جمعة", "سبت"],
//    months: ["يناير", "فبراير", "مارس", "إبريل", "مايو", "يونيه", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"],
//    monthsShort: ["يناير", "فبراير", "مارس", "إبريل", "مايو", "يونيه", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"],
//    today: "Today",
//    clear: "Clear",
//    //format: "dd/MM/yyyy",
//    format: "yyyy/mm/dd",
//    titleFormat: "MM yyyy", /* Leverages same syntax as 'format' */
//    weekStart: 0
//  };

//  $('.custom-datepicker').datepicker({
//    todayHighlight: true,
//    orientation: "bottom right",
//    templates: controls,
//    language: 'ar',
//    startDate: '0d'
 
//  });

//}
