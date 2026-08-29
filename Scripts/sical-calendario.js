function GetDate(LaFecha, CtrlName) {

    var ancho = 470;
    var alto = 570;

    var izquierda =
        Math.max(0, (screen.availWidth - ancho) / 2);

    var arriba =
        Math.max(0, (screen.availHeight - alto) / 2);

    var url =
        '/SicalNet/Forms/Production/Calendar.aspx'
        + '?FormName=' + encodeURIComponent(document.forms[0].name)
        + '&CtrlName=' + encodeURIComponent(CtrlName)
        + '&txtDate=' + encodeURIComponent(LaFecha);

    ChildWindow = window.open(
        url,
        'PopUpCalendar',
        'width=' + ancho
        + ',height=' + alto
        + ',left=' + Math.round(izquierda)
        + ',top=' + Math.round(arriba)
        + ',toolbar=no'
        + ',menubar=no'
        + ',location=no'
        + ',status=no'
        + ',scrollbars=no'
        + ',resizable=no'
    );

    if (ChildWindow) {
        ChildWindow.focus();
    }

    return false;
}