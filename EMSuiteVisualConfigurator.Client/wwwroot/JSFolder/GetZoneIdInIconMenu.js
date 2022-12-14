function GetZoneIdInIconMenu() {
    var zoneInIconMenuId = document.getElementsByClassName("draggable").namedItem("zone").id;
    console.log("Zone in iconMenu id = " + zoneInIconMenuId)
    return parseInt(zoneInIconMenuId);
}