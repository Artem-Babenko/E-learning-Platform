$(window).on("load", function () {
    this.InitLanguageSelect();
});
function InitLanguageSelect() {
    var languageSelect = jQuery('select.site-language-select');
    languageSelect.on('change', function () {
        console.log("change");
        var langValue = languageSelect.prop('value');
        Cookies.set('language', langValue);
        location.reload();
    });
}
//# sourceMappingURL=Layout.js.map