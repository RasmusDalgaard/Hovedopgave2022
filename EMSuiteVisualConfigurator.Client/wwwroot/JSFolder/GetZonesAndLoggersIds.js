function GetZonesAndLoggersIds(siteId) {
    sites = [...document.getElementsByName('site')]
    site = sites.find(site => site.id == siteId)
    //Select all sensors exept the last
    sens = site.getElementsByClassName('sensor')
    sensors = [].slice.call(sens, 0, sens.length - 1)
    //Select all zones exept the last
    zone = site.getElementsByClassName('zone')
    zones = [].slice.call(zone, 0, zone.length - 1)
    //Make an Empty zone dictionary <int, Array>
    zoneDict = {}
    //add entries to zoneDict where key  is zone id and value is array of sensor ID's
    zones.forEach(function (zone) {
        var zone1X = parseInt(zone.getAttribute('x'));
        var zone1Y = parseInt(zone.getAttribute('y')) + 200;
        var zone2X = parseInt(zone.style.width) + zone1X;
        var zone2Y = parseInt(zone.style.height) + zone1Y;
        var zoneID = parseInt(zone.id);
        zoneDict[zoneID] = [];
        sensors.forEach(function (sensor) {
            var sx = sensor.getAttribute('x');
            var sy = sensor.getAttribute('y');
            console.log('zone2x: ' + zone2X)
            console.log('sensorx: ' + sx)
            if (sx > zone1X & sx < zone2X & sy > zone1Y & sy < zone2Y) {
                zoneDict[zoneID].push(parseInt(sensor.id));
            }
        })
    })
    return zoneDict
}