let step = 0;
$(document).ready(function () {
    if (step === 0) {
        $("div.back").css("visibility", "hidden");
    } else {
        $("div.back").css("visibility", "visible");
    }
})

function getNextStep() {
    ++step;
    if (step === 0) {
        $("div.back").css("visibility", "hidden");
    } else {
        $("div.back").css("visibility", "visible");
    }
    if (step === 1) {
        $('.line').height('20%');
    } else if (step === 2) {
        $('.line').height('40%');
    } else if (step === 4) {
        $('.line').height('60%');
    } else if (step === 5) {
        $('.line').height('80%');
    } else if (step === 6) {
        $('.line').height('100%');
    }
    $('.step-style.active').each(function () {
        $(this).fadeOut(300, function () {
            $(this).removeClass('active').next().addClass('active').fadeIn();
            validateNextButton(step);
        })
    });
}

function backStep() {
    --step;
    if (step === 0) {
        $("div.back").css("visibility", "hidden");
        $('#next').attr('disabled', false);
    } else {
        $("div.back").css("visibility", "visible");
        $('#next').attr('disabled', true);
    }
    if (step === 0) {
        $('.line').height('10%');
    } else if (step === 1) {
        $('.line').height('20%');
        validateTerms();
    } else if (step === 2) {
        $('.line').height('40%')
    } else if (step === 3) {
        $('.line').height('40%')
    } else if (step === 4) {
        $('.line').height('60%')
    } else if (step === 5) {
        $('.line').height('80%')
    } else if (step === 6) {
        $('.line').height('100%')
    }
    $('.step-style.active').each(function () {
        $(this).fadeOut(300, function () {
            $(this).removeClass('active').prev().addClass('active').fadeIn();
            validateNextButton(step);
        })
    });
}

function validateNextButton(step) {
    if (step === 0) {
        $('#next').attr('disabled', false);
        return;
    } else if (step === 1) {
        validateTerms();
    } else if (step === 2) {
        validatePersonDate();
    } else if (step === 3) {
        validatePatientDate();
    } else if (step === 4) {
        validateSymptoms();
    } else if (step === 5) {
        validateQuestions();
    }
    if (step === 6) {
        $('#finish').fadeIn();
        $('#next').fadeOut();
    } else {
        $('#finish').fadeOut();
        $('#next').fadeIn();
    }
}

function validateTerms() {
    if ($('input[name="terms"]').is(":checked")) {
        $('#next').attr('disabled', false);
    } else {
        $('#next').attr('disabled', true);
    }
}

function validatePersonDate() {
    if ($("input[name='gender']").is(':checked') && $("input[type=number]").val()) {
        $('#next').attr('disabled', false);
    } else {
        $('#next').attr('disabled', true);   
    }
}

function validatePatientDate() {
    let weight = $("input[name='weight']").is(':checked');
    let smoke = $("input[name='smoke']").is(':checked');
    let suffer = $("input[name='suffer']").is(':checked');
    let high = $("input[name='high']").is(':checked');
    let hypertension = $("input[name='hypertension']").is(':checked');
    if (weight && smoke && suffer && high && hypertension) {
        $('#next').attr('disabled', false);
    } else {
        $('#next').attr('disabled', true);
    }
}

function validateSymptoms() {
    if ($('#txtValue').val()) {
        $('#next').attr('disabled', false);
    } else {
        $('#next').attr('disabled', true);
    }
}

function validateQuestions () {
    if ($(".step-six input").is(':checked')) {
        $('#next').attr('disabled', false);
    } else {
        $('#next').attr('disabled', true);
    }
}
