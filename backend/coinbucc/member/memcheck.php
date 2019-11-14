<?php
session_start();
include("connect.php");
if($_SESSION['user_id']==null) echo "<script>location.href='/login.php'</script>"
?>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.1/css/all.css" integrity="sha384-O8whS3fhG2OnA5Kas0Y9l3cfpmYjapjI0E4theH4iuMD+pLhbf6JI0jIMfYcK3yZ" crossorigin="anonymous">