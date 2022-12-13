function GetElementsInZone(id) {
    var zoneInIconMenuId = document.getElementsClassName("draggable").namedItem("zone").id;
    var zones = document.getElementsByClassName("drag-resize zone").namedItem(id);
    return zoneInIconMenuId;
}