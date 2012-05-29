function ResetSize() {
    document.getElementById("cleft").style.height = (document.documentElement.clientHeight - 110) + "px";
    document.getElementById("cleftandrightline").style.height = (document.documentElement.clientHeight - 105) + "px";
    document.getElementById("cright").style.height = (document.documentElement.clientHeight - 110) + "px";
    document.getElementById("cright").style.width = (document.documentElement.clientWidth - 215) + "px";
    if (document.documentElement.clientWidth < 1000) {
        document.getElementById("cibody").style.width = "760px";
    }
    document.getElementById("cibody").style.height = (document.documentElement.clientHeight - 115) + "px";
}

//关闭窗口
function closeWindow() {
    window.opener = null;
    window.open(' ', '_self', ' ');
    window.close();
}
