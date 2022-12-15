function GetAccessPointsAndLoggersIds(siteId) {
    //select all sites
    sites = [...document.getElementsByName('site')]
    site = sites.find(site => site.id == siteId)
    //Select all sensors exept the last
    sens = site.getElementsByClassName('sensor')
    sensors = [].slice.call(sens, 0, sens.length - 1)
    //Select all accesspoints exept the last
    access = site.getElementsByClassName('accesspoint')
    accesspoints = [].slice.call(access, 0, access.length - 1)
    //Make an Empty zone dictionary <int, Array>
    accessDict = {}
    // add entries to accessDict where key is accesspoint ID and value is array of sensor ID's
    sensors.forEach(function (sensor) {
        var closestDistance = null;
        var closestID
        var sx = sensor.getAttribute('x')
        var sy = sensor.getAttribute('y')
        accesspoints.forEach(function (ap) {
            var apX = parseInt(ap.getAttribute('x'));
            var apY = parseInt(ap.getAttribute('y')) + 100
            var apID = parseInt(ap.id);
            var dist = Math.sqrt(Math.pow(apX - sx, 2) * Math.pow(apY - sy, 2))
            if (dist < closestDistance || closestDistance == null) {
                closestID = apID
                closestDistance = dist
            }
        })
        if (accessDict[closestID] == null) {
            accessDict[closestID] = []
        }
        accessDict[closestID].push(parseInt(sensor.id))
    })
    return accessDict
}