let sumPushUp = 0;
let sumMoney = 0;
$(".money").each(function () {
    sumMoney += parseInt($(this).text());
});

$('.sum').children().eq(0).text('Tổng tiền phạt: ' + sumMoney);
$(".push-up").each(function () {
    sumPushUp += parseInt($(this).text());
});

$('.sum').children().eq(1).text('Tổng chống đẩy: ' + sumPushUp);


$(function () {
    $('input[name="datefilter"]').daterangepicker({
        autoUpdateInput: false,
        locale: {
            cancelLabel: 'Clear'
        },
        ranges: {
            'Today': [moment(), moment()],
            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        },
        "alwaysShowCalendars": true
    });

    $('input[name="datefilter"]').on('apply.daterangepicker', function (ev, picker) {
        $(this).val(picker.startDate.format('MM/DD/YYYY') + ' - ' + picker.endDate.format('MM/DD/YYYY'));
        $('input[name ="startDate"]').val(picker.startDate.format('YYYY-MM-DD'));
        $('input[name ="endDate"]').val(picker.endDate.format('YYYY-MM-DD'));
        $('#submit').click();
    });

    $('input[name="datefilter"]').on('cancel.daterangepicker', function (ev, picker) {
        $(this).val('');
    });
});

  function fnSuccess() {  
      let sumPushUp = 0;
      let sumMoney = 0;
      $(".money").each(function () {
          sumMoney += parseInt($(this).text());
      });

      $('.sum').children().eq(0).text('Tổng tiền phạt: ' + sumMoney);
      $(".push-up").each(function () {
          sumPushUp += parseInt($(this).text());
      });

      $('.sum').children().eq(1).text('Tổng chống đẩy: ' + sumPushUp);
    }  


