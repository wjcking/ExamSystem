
    var player = document.getElementById("player");
    var interval;
     
    function openMediaFile(media) {
       player.url =media; 
       player.controls.play();
    }


    function getPosition( txtPosition) {

        $("#"+txtPosition).val(player.controls.currentPosition);

    }

    function playMedia(startPosition, endPosition) {

        if (startPosition == "" || endPosition == "")
            return;
        
        if (isNaN(startPosition) || isNaN(endPosition))
            return;
      
        if (startPosition >= endPosition)
            return;
            
        clearInterval(interval);
         
        player.controls.currentPosition = startPosition;
        player.controls.play();
        
        interval =setInterval(function() {
        
                var playState = player.playState;
            
                if (playState == 3) {
                     
    //                    $("#divPosition").html(player.controls.currentPosition);
                    
                    if (player.controls.currentPosition > endPosition) {
                        
                        player.controls.pause();
                      
                        clearInterval(interval);
                    }
                }
                
            }, 100);
            
    }  
