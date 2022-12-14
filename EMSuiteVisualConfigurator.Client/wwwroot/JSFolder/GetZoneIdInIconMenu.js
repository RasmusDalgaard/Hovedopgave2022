function GetZoneIdInIconMenu() {
    var zoneInIconMenuId = document.getElementsByClassName("draggable").namedItem("zone").id;
    return parseInt(zoneInIconMenuId);
}