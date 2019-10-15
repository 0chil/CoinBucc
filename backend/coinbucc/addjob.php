<?
include("member/connect.php");
$jobstring=$_GET['job'];
$guid=$_GET['guid'];
$user_id=$_GET['user_id'];

$query = "INSERT INTO jobs VALUES('','$user_id','$guid','$jobstring','','')";
$result = mysqli_query($con, $query);
?>
<script>location.href='minermanage.php?guid=<?=$guid?>'</script>