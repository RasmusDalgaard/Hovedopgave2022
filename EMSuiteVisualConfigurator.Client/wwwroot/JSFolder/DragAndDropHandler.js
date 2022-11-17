function dragstart_handler(className) {
    interact(className).draggable({
        listeners: {
            start(event) {
                console.log("dragStart")
                event.currentTarget.style.border = "dashed";
                event.orginalEvent.dataTransfer.setData("text", event.target.id);
                event.orginalEvent.effectAllowed = "copyMove";
            },            
        }
    })
}

function dragover_handler(dropTarget) {
    interact(dropTarget).dropzone({
        listeners: {
            move(event) {
                console.log("dragOver")
                // Change the target element's border to signify a drag over event
                // has occurred
                event.currentTarget.style.background = "lightblue";
                event.preventDefault();
            },
        }
    })
}

function drop_handler(dropTarget) {
    interact(dropTarget).dropzone({
        listeners: {
            ondrop(event) {
                console.log("Drop")
                event.preventDefault();
                var id = event.dataTransfer.getData("text");
                // Only Move the element if the source and destination ids are both "move"
                if (id == "src_move" && event.target.id == "dest_move")
                    event.target.appendChild(document.getElementById(id));
                // Copy the element if the source and destination ids are both "copy"
                if (id == "src_copy" && event.target.id == "dest_copy") {
                    var nodeCopy = document.getElementById(id).cloneNode(true);
                    nodeCopy.id = "newId";
                    event.target.appendChild(nodeCopy);
                }
            },
        }
    })
}

function dragend_handler(className) {
    interact(className).draggable({
        listeners: {
            end(event) {
                console.log("dragEnd")
                event.target.style.border = "solid black";
                console.log(event.dataTransfer?.clearData());
            },
        }
    })
}