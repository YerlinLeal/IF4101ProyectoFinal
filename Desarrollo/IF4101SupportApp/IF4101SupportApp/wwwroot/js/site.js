var $th = $('.scroll-vertical').find('thead th')
$('.scroll-vertical').on('scroll', function () {
    $th.css('transform', 'translateY(' + this.scrollTop + 'px)');
});

$(function () {
    LoadTable();
});

function LoadTable() {
    $('#table-recorded-issues').DataTable({
        ajax: {
            url: '/Issue/GetAll',
            dataSrc: '',
        },
        columns: [
            {
                "render": function (data, type, s, meta) {
                    return '<button class="hvr-bounce-in" data-toggle="modal" data-target="#IssueDetailsModal" onclick="LoadIssue(' + s.reportNumber + ')"><i class="fa fa-eye" aria-hidden="true"></i></div></td ></button >'
                }
            },
            { data: 'reportNumber' },
            {
                "render": function (data, type, s, meta) {
                    return s.employeeName + ' ' + s.firstSurname;
                }
            },
            {
                "render": function (data, type, s, meta) {
                    if (s.classification == 'A') {
                        return 'High'
                    } else if (s.classification == 'M') {
                        return 'Half'
                    } else if (s.classification == 'B') {
                        return 'Low'
                    } else {
                        return ''
                    }
                }
            },
            {
                "render": function (data, type, s, meta) {
                    if (s.status == 'I') {
                        return 'Inserted'
                    } else if (s.status == 'A') {
                        return 'Assigned'
                    } else if (s.status == 'P') {
                        return 'In progress'
                    } else if (s.status == 'R') {
                        return 'Resolved'
                    } else {
                        return ''
                    }
                }
            },
            { data: 'creationDate' },
            { data: 'reportTimestamp' }
        ]
    });

}

function LoadIssue(reportNumber) {
    $.ajax({
        url: "/Issue/GetIssue",
        data: {"reportNumber": reportNumber},
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (issue) {
            var form = $('#form-issue-details');
            form.find("#reportNumberIssue").val(issue.reportNumber);
            form.find("#userIssue").val("BD client");
            form.find("#emailIssue").val("BD client");
            form.find("#phoneIssue").val("BD client");
            form.find("#addressIssue").val("BD client");
            form.find("#secondContactIssue").val("BD client");
            form.find("#statusIssue").val(issue.status);
            form.find("#classificationIssue").val(issue.classification);
            form.find("#contactEmailIssue").val("BD client");
            form.find("#contactPhoneIssue").val("BD client");
            
            if (issue.employeeAssigned != null) {
                form.find("#supportUserAssignedIssueInput").val(issue.employeeName + ' ' + issue.firstSurname + ' ' + issue.secondSurname);
            } else {
                form.find("#supportUserAssignedIssueInput").val("Not assigned");
            }

            if (issue.comments == null) {
                form.find("#commentsIssue").val("No comment");
            } else {
                form.find("#commentsIssue").val(issue.comments);
            }
        },
        error: function (errorMessage) {
            console.log("Error");
        }
    });

}

function LoadSupportUser() {
    $(document).ready(function () {
        $.ajax({
            url: "",
            data: { "reportNumber": reportNumber },
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",

            success: function (data) {
                /*
                $.each(data, function (key, item) {
                    $("#supportUserAssignedIssue").append('<option value=' + id + '>' + nombre + '</option>');
                });
               */
            },
            error: function (errorMessage) {

            }
        });

    });
}
