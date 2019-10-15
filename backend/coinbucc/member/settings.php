<?
session_start();
include("connect.php");
if($_SESSION['user_id']==null) echo "<script>location.href='/'</script>";

$arr_jobnum_to_eng = array("All done","shutdown","reboot","update miner","update overclock settings");
?>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.1/css/all.css">