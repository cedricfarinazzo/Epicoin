$(document).ready(function () {
	(function ($) {
		$(".dropdown-button").dropdown();
		Materialize.updateTextFields();
		$('select').material_select();
		$('.materialboxed').materialbox();
		$(".button-collapse").sideNav();
		$('.parallax').parallax();
	})(jQuery);
});
