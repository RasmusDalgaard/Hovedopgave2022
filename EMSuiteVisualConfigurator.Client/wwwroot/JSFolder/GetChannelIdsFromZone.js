function GetChannelIdsFromZone(id) {
    var zone = document.getElementsByClassName("drag-resize zone").namedItem(String(id));
    console.log(zone)
    var channels = document.getElementsByClassName("draggable").namedItem("sensor");
    console.log(channels)
    return [1,2,3];
}