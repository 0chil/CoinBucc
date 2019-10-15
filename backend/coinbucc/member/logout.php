<?php

session_start();

if($_SESSION['user_id']!=null){
   session_destroy();
}

echo "<script>location.href='../';</script>";

?>