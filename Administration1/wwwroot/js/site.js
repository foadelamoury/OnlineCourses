

function ShowFormModal(ID, Url) {
  let urlPage = "";
  if (ID == 0) {
      urlPage = Url;
  } else {
      urlPage = Url + "/" + ID;
  }
    window.location.href = urlPage;

}

function RemoveFile(e, name) {
    // alert(name);
    debugger;
    $('#' + name + '').val("");
    $('#' + name + '').css("display", "none");
    $("#RemoveBtn" + name + "").css("display", "none");
    $("#ShowBtn" + name + "").css("display", "none");
}



var DT1;
function IntiDataTable(add, Export, search/*, PrintText*/, ExcelText, SearchText, ClearSearchText, ExportColumns, CreateText, addpramter = 0, removeOrderCol = '0', activate) {
    /* demo scripts for change table color */
    /* change background */
    var value = 'ShowFormModal(' + addpramter + ',"Create")';
    DT1 = $('#dt-basic-example').DataTable({
        order: [],
        columnDefs: [
            {
                orderable: false,
                targets: [0, 1, -1]
            },
            {
                orderable: false,
                targets: removeOrderCol
            },

        ],
        //Rows Selction
        select: {
            style: 'multi',
            selector: 'td:first-child input',
            info: false
        },

        responsive: true,
        lengthChange: false,
        pageLength: 15,
        dom: "<'row mb-3'<'col-sm-12 col-md-3 col-lg-3 d-flex align-items-center justify-content-start'f><'col-sm-12 col-md-9 col-lg-9 d-flex align-items-center justify-content-end'B>>" +
            "<'row'<'col-sm-12 table-responsive'tr>>" +
            "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
        "language": {
            "lengthMenu": "عرض _MENU_ بيان",
            "info": "عرض _START_ الى _END_ من _TOTAL_ سجل",
            "infoEmpty": "لا توجد بيانات",
            "zeroRecords": "لا توجد بيانات",
            "infoFiltered": "(تمت تصفيته من _MAX_ سجل)",
            /* change the default text for 'next' and 'previous' with icons */
            "paginate": {
                previous: "<i class='fa fa-chevron-right'></i>",
                next: "<i class='fa fa-chevron-left'></i>"
            },
        },

        buttons: [
            {
                text: ' <i class="fa fa-filter ml-2"></i>' + SearchText,
                name: 'advancedSearch',
                className: 'btn_white btn-pills btn-sm searchbtn'
            },
            {
                text: '<i class="fas fa-eraser ml-2"></i>' + ClearSearchText,
                name: 'clearSearch',
                className: 'btn_white btn-pills btn-sm clearsearchbtn'
            },
            {
                extend: 'excelHtml5',
                text: ' <i class="fa fa-file-excel ml-2"></i>' + ExcelText,
                className: 'btn_white btn-pills btn-sm excelbtn',
                exportOptions: {
                    // select columns to export
                    columns: ExportColumns,
                    //columns: ':not(.select-checkbox)',
                    modifier: { order: 'index' }
                },
            },
            {
                text: ' <i class="fa fa-toggle-on ml-2"></i>' + 'تفعيل/تعطيل',
                name: 'activate',
                className: 'btn-primary btn-pills btn-sm activatebtn'
            },
            //Print
            //{
            //  extend: 'print',
            //  text: ' <i class="fa fa-print ml-2"></i>' + PrintText ,
            //  titleAttr: 'Print Table',
            //  className: 'btn-primary btn-pills btn-sm ',
            //  exportOptions: {
            //    columns: ExportColumns,//':not(.select-checkbox)',
            //    modifier: {
            //      page: 'current'
            //    }
            //  },
            //},
            {
                text: ' <i class="fa fa-plus-circle ml-2"></i>' + CreateText,
                name: 'add',
                className: 'btn-main-bg btn-pills btn-sm addbtn'
            }
        ],
    });
    if (add == 0) {
        DT1.buttons('.addbtn').nodes().addClass('d-none');
    }
    if (Export == 0) {
        DT1.buttons('.excelbtn').nodes().addClass('d-none');
    }
    if (search == 0) {
        DT1.buttons('.searchbtn').nodes().addClass('d-none');
        DT1.buttons('.clearsearchbtn').nodes().addClass('d-none');
    }
    if (activate == 0) {
        DT1.buttons('.activatebtn').nodes().addClass('d-none');
    }


    // //Select all rows from select Rows
    DT1
        .on('select', function (e, dt, type, indexes) {
            if (DT1.rows({ selected: true }).ids().toArray().length === DT1.rows({ page: 'current' }).ids().toArray().length) {
                $('.selectAll').prop('checked', true);
            }
        })
        .on('deselect', function (e, dt, type, indexes) {
            if ($(".selectAll").is(":checked")) {
                $('.selectAll').prop('checked', false);
            }
        });

    //.........
    //Select all rows from selectAll
    $(".selectAll").on("click", function (e) {
        if ($(this).is(":checked")) {
            DT1.rows({ page: 'current' }).select();
            $('.selectRow').prop('checked', true);
            $('.activate').prop('disabled', false);
            $('.activatebtn').prop('disabled', false);

        } else {
            DT1.rows({ page: 'current' }).deselect();
            $('.activate').prop('disabled', true);
            $('.activatebtn').prop('disabled', true);
            $('.selectRow').prop('checked', false);
        }
    });
    $('.activate').prop('disabled', true);
    $('.activatebtn').prop('disabled', true);
    //Active and deactivate selection buttons

    //.......

    $('.selectRow').on("click", function () {

        if ($('.selectRow').is(":checked")) {
            $('.activate').prop('disabled', false);

            $('.activatebtn').prop('disabled', false);
        } else {
            $('.activate').prop('disabled', false);

            $('.activatebtn').prop('disabled', true);
            $('.selectAll').prop('checked', false);
        };

    });
    $('.custom-select').css("width", "auto");
    $(".dataTables_filter label").css("display", "inline-flex");
    $(".dataTables_filter input").attr("placeholder", "بحث");
    $(".addbtn").attr('onclick', value);
    $(".searchbtn").attr('onclick', 'ShowSearchModal("AdvancedSearch")');
    $(".clearsearchbtn").attr('onclick', 'ClearSearch()')

    //Active and deactivate selection buttons in other pages
    $('#dt-basic-example').on('draw.dt', function () {
        $('.selectRow').on("click", function () {
            if ($('.selectRow').is(":checked")) {
                $('.activate').prop('disabled', false);

                $('.activatebtn').prop('disabled', false);
            } else {
                $('.activate').prop('disabled', false);

                $('.activatebtn').prop('disabled', true);
            }
        });
    });
    //.......

    $(".searchbtn").attr('data-toggle', 'modal').attr('data-target', '#advanced-search-modal-lg');
    //cancel selction on page change
    $('#dt-basic-example').on('page.dt', function () {
        DT1.rows().deselect();
        $('.activate').prop('disabled', false);

        $('.activatebtn').prop('disabled', true);
        $('.selectRow').prop('checked', false);
        $('.selectAll').prop('checked', false);
    });
    $('.dataTables_filter input').on('keyup', function () {
        DT1.search(AdaptForNormalize($(this).val())).draw();
    });
    $('.activate').on("click", function () {
        var data = [];
        data = getSelectedItems();
        console.log(data);
        $.ajax({
            type: 'Post',
            dataType: "json",
            url: "Activate",
            traditional: true,
            data: { selectedList: data },
            success: function () {
                console.log("success");
            },
            error: function () {
                console.log("error");
            }
        })
    });
    $('.activatebtn').on("click", function () {
        var data = [];
        data = getSelectedItems();
        console.log(data);
        $.ajax({
            type: 'Post',
            dataType: "json",
            url: "Activate",
            traditional: true,
            data: { Ids: data },
            success: function (data) {
                if (data == "Success")
                    window.location.reload();
            },
            error: function () {
                console.log("error");
            }
        })
    });

}


function IntiDataTableStudent(add, Export, search/*, PrintText*/, ExcelText, SearchText, ClearSearchText, ExportColumns, CreateText, addpramter = 0, removeOrderCol = '0', activate) {
    /* demo scripts for change table color */
    /* change background */
    var value = 'ShowFormModal(' + addpramter + ',"Create")';
    DT1 = $('#dt-basic-example').DataTable({
        order: [],
        columnDefs: [
            {
                orderable: false,
                targets: [0, 1, -1]
            },
            {
                orderable: false,
                targets: removeOrderCol
            },

        ],
        //Rows Selction
        select: {
            style: 'multi',
            selector: 'td:first-child input',
            info: false
        },

        responsive: true,
        lengthChange: false,
        pageLength: 15,
        dom: "<'row mb-3'<'col-sm-12 col-md-3 col-lg-3 d-flex align-items-center justify-content-start'f><'col-sm-12 col-md-9 col-lg-9 d-flex align-items-center justify-content-end'B>>" +
            "<'row'<'col-sm-12 table-responsive'tr>>" +
            "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
        "language": {
            "lengthMenu": "عرض _MENU_ بيان",
            "info": "عرض _START_ الى _END_ من _TOTAL_ سجل",
            "infoEmpty": "لا توجد بيانات",
            "zeroRecords": "لا توجد بيانات",
            "infoFiltered": "(تمت تصفيته من _MAX_ سجل)",
            /* change the default text for 'next' and 'previous' with icons */
            "paginate": {
                previous: "<i class='fa fa-chevron-right'></i>",
                next: "<i class='fa fa-chevron-left'></i>"
            },
        },

        buttons: [
            {
                text: ' <i class="fa fa-filter ml-2"></i>' + SearchText,
                name: 'advancedSearch',
                className: 'btn-primary btn-pills btn-sm searchbtn'
            },
            {
                text: '<i class="fas fa-eraser ml-2"></i>' + ClearSearchText,
                name: 'clearSearch',
                className: 'btn-primary btn-pills btn-sm clearsearchbtn'
            },
            {
                extend: 'excelHtml5',
                text: ' <i class="fa fa-file-excel ml-2"></i>' + ExcelText,
                className: 'btn-primary btn-pills btn-sm excelbtn',
                exportOptions: {
                    // select columns to export
                    columns: ExportColumns,
                    //columns: ':not(.select-checkbox)',
                    modifier: { order: 'index' }
                },
            },
            {
                text: ' <i class="fa fa-toggle-on ml-2"></i>' + 'تفعيل/تعطيل',
                name: 'activate',
                className: 'btn-primary btn-pills btn-sm activatebtn'
            },
            //Print
            //{
            //  extend: 'print',
            //  text: ' <i class="fa fa-print ml-2"></i>' + PrintText ,
            //  titleAttr: 'Print Table',
            //  className: 'btn-primary btn-pills btn-sm ',
            //  exportOptions: {
            //    columns: ExportColumns,//':not(.select-checkbox)',
            //    modifier: {
            //      page: 'current'
            //    }
            //  },
            //},
            {
                text: ' <i class="fa fa-plus-circle ml-2"></i>' + CreateText,
                name: 'add',
                className: 'btn-primary btn-pills btn-sm addbtn'
            }
        ],
    });
    if (add == 0) {
        DT1.buttons('.addbtn').nodes().addClass('d-none');
    }
    if (Export == 0) {
        DT1.buttons('.excelbtn').nodes().addClass('d-none');
    }
    if (search == 0) {
        DT1.buttons('.searchbtn').nodes().addClass('d-none');
        DT1.buttons('.clearsearchbtn').nodes().addClass('d-none');
    }
    if (activate == 0) {
        DT1.buttons('.activatebtn').nodes().addClass('d-none');
    }


    // //Select all rows from select Rows
    DT1
        .on('select', function (e, dt, type, indexes) {
            if (DT1.rows({ selected: true }).ids().toArray().length === DT1.rows({ page: 'current' }).ids().toArray().length) {
                $('.selectAll').prop('checked', true);
            }
        })
        .on('deselect', function (e, dt, type, indexes) {
            if ($(".selectAll").is(":checked")) {
                $('.selectAll').prop('checked', false);
            }
        });

    //.........
    //Select all rows from selectAll
    $(".selectAll").on("click", function (e) {
        if ($(this).is(":checked")) {
            DT1.rows({ page: 'current' }).select();
            $('.selectRow').prop('checked', true);
            $('.activate').prop('disabled', false);
            $('.activatebtn').prop('disabled', false);

        } else {
            DT1.rows({ page: 'current' }).deselect();
            $('.activate').prop('disabled', true);
            $('.activatebtn').prop('disabled', true);
            $('.selectRow').prop('checked', false);
        }
    });
    $('.activate').prop('disabled', true);
    $('.activatebtn').prop('disabled', true);
    //Active and deactivate selection buttons

    //.......

    $('.selectRow').on("click", function () {

        if ($('.selectRow').is(":checked")) {
            $('.activate').prop('disabled', false);

            $('.activatebtn').prop('disabled', false);
        } else {
            $('.activate').prop('disabled', false);

            $('.activatebtn').prop('disabled', true);
            $('.selectAll').prop('checked', false);
        };

    });
    $('.custom-select').css("width", "auto");
    $(".dataTables_filter label").css("display", "none");
    $(".dataTables_filter input").attr("placeholder", "بحث");
    $(".addbtn").attr('onclick', value);
    $(".searchbtn").attr('onclick', 'ShowSearchModal("AdvancedSearch")');
    $(".clearsearchbtn").attr('onclick', 'ClearSearch()')

    //Active and deactivate selection buttons in other pages
    $('#dt-basic-example').on('draw.dt', function () {
        $('.selectRow').on("click", function () {
            if ($('.selectRow').is(":checked")) {
                $('.activate').prop('disabled', false);

                $('.activatebtn').prop('disabled', false);
            } else {
                $('.activate').prop('disabled', false);

                $('.activatebtn').prop('disabled', true);
            }
        });
    });
    //.......

    $(".searchbtn").attr('data-toggle', 'modal').attr('data-target', '#advanced-search-modal-lg');
    //cancel selction on page change
    $('#dt-basic-example').on('page.dt', function () {
        DT1.rows().deselect();
        $('.activate').prop('disabled', false);

        $('.activatebtn').prop('disabled', true);
        $('.selectRow').prop('checked', false);
        $('.selectAll').prop('checked', false);
    });
    $('.dataTables_filter input').on('keyup', function () {
        DT1.search(AdaptForNormalize($(this).val())).draw();
    });
    $('.activate').on("click", function () {
        var data = [];
        data = getSelectedItems();
        console.log(data);
        $.ajax({
            type: 'Post',
            dataType: "json",
            url: "Activate",
            traditional: true,
            data: { selectedList: data },
            success: function () {
                console.log("success");
            },
            error: function () {
                console.log("error");
            }
        })
    });
    $('.activatebtn').on("click", function () {
        var data = [];
        data = getSelectedItems();
        console.log(data);
        $.ajax({
            type: 'Post',
            dataType: "json",
            url: "Activate",
            traditional: true,
            data: { Ids: data },
            success: function (data) {
                if (data == "Success")
                    window.location.reload();
            },
            error: function () {
                console.log("error");
            }
        })
    });

}


function getSelectedItems() {
    var data = DT1.rows({ selected: true }).data();
    var newarray = [];
    for (var i = 0; i < data.length; i++) {
        newarray.push(data[i][1]);
    }

    return newarray;
}



function ClearSearch() {
    var currentUrl = window.location.href;
    var split = currentUrl.split("/");
    var clearSearchUrl = split.slice(0, split.length - 1).join("/") + "/ClearSearch";
    window.location.href = clearSearchUrl;
}
function ClearSearchReport(objectName) {

    var currentUrl = window.location.href;
    var split = currentUrl.split("/");
    var clearSearchUrl = split.slice(0, split.length - 1).join("/") + "/" + objectName + "ClearSearch";
    window.location.href = clearSearchUrl;
}
function ShowSearchModal(Url) {

    let urlPage = "";
    urlPage = Url;
    $.ajax({
        url: urlPage,
        data: {}
    }).done(function (htmlResponse) {

        $('#ModalSearch').html(htmlResponse);
        runDatePicker();
        $('#search-example-modal-lg').modal();
    });
}

function validate() {
    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    debugger;
    var forms = document.getElementsByClassName('needs-validation');
    // Loop over them and prevent submission
    var validation = Array.prototype.filter.call(forms, function (form) {
        form.addEventListener('submit', function (event) {
            var validfiles = true;
            $("input[type=file]").each(function () {
                var att = $(this).attr("accept").split(",");

                if (att != "" && att != null && att != undefined) {
                    var input = $(this).prop("files");
                    for (var i = 0; i < input.length; i++) {
                        var split = input[i].name.split(".");
                        if (!att.includes('.' + split[split.length - 1].toLowerCase())) {
                            $(this).css({
                                "border-color": "#dc3545",
                                "border-weight": "1px",
                                "border-style": "solid"
                            });
                            validfiles = false;
                        }
                        else {
                            $(this).css({
                                "border-color": "#28a745",
                                "border-weight": "1px",
                                "border-style": "solid"
                            })
                        }
                    }
                }

            });
            if (form.checkValidity() === false || validfiles == false) {
                ReturnToInValidTab();
                event.preventDefault();
                event.stopPropagation();
            }
            debugger;
            var urlFields = $('input[type=url]');
            for (var i = 0; i < urlFields.length; i++) {
                var url = $(urlFields[i]).val();
                if (url != null) {
                    if (url.trim().startsWith("http://") || url.trim().startsWith("https://") || url.trim().startsWith("Http://") || url.trim().startsWith("Https://")) {
                        url = url.replace("http://", "").replace("https://", "");
                        url = url.replace("Http://", "").replace("Https://", "");
                        $(urlFields[i]).val(url);
                        $(urlFields[i]).attr("type", "text");
                    }
                }
            }


            //var FileExensions = ["jpg", "png", "jpeg", "gif"];
            //$('#image').change(function () {
            //  var split = $('#smallimageinput')[0].value.split(".");
            //  var splitfile = $('#SmallImage').val().split('.');
            //  if ($('#smallimageinput')[0].value == '' || (FileExensions.includes(splitfile[splitfile.length - 1].toLowerCase()) && $('#smallimageinput')[0].value == '') || FileExensions.includes(split[split.length - 1].toLowerCase())) {
            //  }
            //  else {
            //    $('#labelsmallimage').css({
            //      "border-color": "#fd3995",
            //      "border-weight": "1px",
            //      "border-style": "solid"
            //    })
            //    event.preventDefault();
            //    event.stopPropagation();
            //  }
            //})

            //var photo = $('#photo').val();
            //var FileExensions = ["jpg", "png", "jpeg", "gif"];
            //var split = $('#photo')[0].value.split(".");
            //var splitfile = $('#photo').val().split('.');
            //if ($('#photo')[0].value == '' || (FileExensions.includes(splitfile[splitfile.length - 1].toLowerCase()) && $('#photo')[0].value == '') || FileExensions.includes(split[split.length - 1].toLowerCase())) {

            //  $('#photo').css({
            //    "border-color": "#fd3995",
            //    "border-weight": "1px",
            //    "border-style": "solid"
            //  })
            //}


            form.classList.add('was-validated');
        }, false);
    });
}

function ReturnToInValidTab() {

    var firstInvalid = $('.form-control:invalid').first()
    var t = firstInvalid.closest('.tab-pane');
    if (t == null)
        t = $('.tab-pane').first();
    var tabId = t.attr('id');
    if (tabId != undefined) {
        $('.tab-pane').removeClass('active show');
        $('[href="#' + tabId + '"]').tab('show');
        $('#' + tabId).addClass('active show');
    }
}

function DeleteObject(obj) {
    if ($(obj).hasClass("LnkDisabled")) {
        obj.preventDefault();
    }
    var ID = $(obj).attr("data-id");
    var area = $(obj).attr("data-area");
    var ObjectName = $(obj).attr("data-Controller");
    var Action1 = $(obj).attr("data-Action1");
    var Action2 = $(obj).attr("data-Action2");
    var Name = $(obj).attr("data-Name");
    var MSG1 = $(obj).attr("data-Msg1");
    var MSG2 = $(obj).attr("data-Msg2");
    var okButt = $('.OkButton').text();
    var CancelButt = $('.cancelButton').text();
    $.ajax({
        url: "/" + area + "/" + ObjectName + "/" + Action1 + "/" + ID,
        //contentType: "application/json; charset=utf-8",
        //dataType: "json",
        type: "GET",
        success: function (response) {
            if (response) {
                swal({
                    text: MSG1 + " " + Name + "?",
                    icon: "warning",
                    buttons: [CancelButt, okButt],
                    dangerMode: true,
                })
                    .then((willDelete) => {
                        if (willDelete) {
                            $.ajax({
                                url: "/" + area + "/" + ObjectName + "/" + Action2 + "/" + ID,
                                //contentType: "application/json; charset=utf-8",
                                //dataType: "json",
                                type: "GET",
                                success: function (response) {
                                    if (response == "OK") {
                                        swal({
                                            text: MSG2,
                                            icon: "success",
                                        });
                                        setTimeout(function () {
                                            location.reload();
                                        }, 500);
                                    }
                                    else {
                                        swal({
                                            text: response,
                                            icon: "warning",
                                        });
                                    }
                                }
                            });

                        }
                    });
            }
            else {
                window.location.href = "/General/HomePage/AccessDenied";
            }

        }

    });
}

$('.fa-calendar').parent().click(function () {
    var y = $(this).parent().siblings('.custom-datepicker');
    y.datepicker({
        todayHighlight: true,
        orientation: "bottom right",
        templates: controls,
        language: 'ar'
    }).focus();
});
//datapicker
var controls = {
    leftArrow: '<i class="fa fa-angle-right" style="font-size: 1.25rem"></i>',
    rightArrow: '<i class="fa fa-angle-left" style="font-size: 1.25rem"></i>'
}

var runDatePicker = function () {
    $.fn.datepicker.dates['ar'] = {
        days: ["أحد", "أثنين", "ثلاثاء", "أربعاء", "خميس", "جمعة", "سبت"],
        daysShort: ["أحد", "أثنين", "ثلاثاء", "أربعاء", "خميس", "جمعة", "سبت"],
        daysMin: ["أحد", "أثنين", "ثلاثاء", "أربعاء", "خميس", "جمعة", "سبت"],
        months: ["يناير", "فبراير", "مارس", "إبريل", "مايو", "يونيه", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"],
        monthsShort: ["يناير", "فبراير", "مارس", "إبريل", "مايو", "يونيه", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"],
        today: "Today",
        clear: "Clear",
        //format: "dd/MM/yyyy",
        format: "yyyy/mm/dd",
        titleFormat: "MM yyyy", /* Leverages same syntax as 'format' */
        weekStart: 0
    };

    $('.custom-datepicker').datepicker({
        todayHighlight: true,
        orientation: "bottom right",
        templates: controls,
        language: 'ar',
        //endDate: '0d',
        //startDate: '-2y'
    });

}


var runDatePickerLimiting = function () {
    $.fn.datepicker.dates['ar'] = {
        days: ["أحد", "أثنين", "ثلاثاء", "أربعاء", "خميس", "جمعة", "سبت"],
        daysShort: ["أحد", "أثنين", "ثلاثاء", "أربعاء", "خميس", "جمعة", "سبت"],
        daysMin: ["أحد", "أثنين", "ثلاثاء", "أربعاء", "خميس", "جمعة", "سبت"],
        months: ["يناير", "فبراير", "مارس", "إبريل", "مايو", "يونيه", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"],
        monthsShort: ["يناير", "فبراير", "مارس", "إبريل", "مايو", "يونيه", "يوليو", "أغسطس", "سبتمبر", "أكتوبر", "نوفمبر", "ديسمبر"],
        today: "Today",
        clear: "Clear",
        //format: "dd/MM/yyyy",
        format: "yyyy/mm/dd",
        titleFormat: "MM yyyy", /* Leverages same syntax as 'format' */
        weekStart: 0
    };

    $('.custom-datepicker').datepicker({
        todayHighlight: true,
        orientation: "bottom right",
        templates: controls,
        language: 'ar',
        startDate: '0d'
        //endDate: '+1d',
        //datesDisabled: '-1d'
        //endDate: '0d',
        //startDate: '-2y'
    });

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
