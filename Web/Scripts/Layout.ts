

$(window).on("load", function () {

    this.InitLanguageSelect();

});

function InitLanguageSelect() {
    const languageSelect: JQuery = jQuery('select.site-language-select');

    languageSelect.on('change', function () {
        console.log("change");
        const langValue: string = languageSelect.prop('value');
        Cookies.set('language', langValue);
        location.reload();
    });
}

