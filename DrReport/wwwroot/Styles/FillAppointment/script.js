function validateTerms() {
  if ($('input[name="terms"]').is(":checked")) {
      $('#confirm').attr('disabled', false);
  } else {
      $('confirm').attr('disabled', true);
  }
}