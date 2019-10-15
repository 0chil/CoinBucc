<?
include_once("member/settings.php");
?>
<!doctype html>
<html class="h-100">
  <head>
    <title>Manage Miner <?=$_GET['guid']?></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link rel="stylesheet" href="css/global.css">
  </head>
  <nav class="navbar fixed-top navbar-expand-lg navbar-light bg-mdark text-white">
    <div class="container">
      <a href="/"><img class="img-fluid" style="height:40px;" src="img/COINBUCC-0.5.png"></a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
        <ul class="navbar-nav">
          <li class="nav-item">
            <a class="nav-link" href="dashboard.php">Dashboard</a>
          </li>
          <li class="nav-item active">
            <a class="nav-link" href="minermanage.php">Miner Management</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="minermanageall.php">Group Management</a>
          </li>
          <li class="nav-item">
            <!-- <a class="nav-link" href="marketprice.html">Market Price</a> -->
          </li>
          <li class="nav-item">
            <!-- <a class="nav-link" href="/setting.php">Setting</a> -->
          </li>
          <li class="nav-item">
            <a class="btn btn-outline-primary" href="member/logout.php"><i class="fas fa-sign-out-alt"></i></a>
          </li>
        </ul>
      </div>
    </div>
  </nav>

  <body class="h-100">
    <div class="row justify-content-center mx-4 mt-5">
      <?
      $query = "SELECT count(*) as cnt FROM miners WHERE uid='$_SESSION[user_id]'";
      $result = mysqli_query($con, $query);
      $cnt = mysqli_fetch_assoc($result)['cnt'];
      $query = "SELECT * FROM miners WHERE uid='$_SESSION[user_id]'";
      $result = mysqli_query($con, $query);
      for($i=0; $row = mysqli_fetch_array($result);$i++){
        if($_GET['page']!=$i) continue;
      ?>
      
      <a class="align-self-center mx-2 <?=$i>0?'':'d-none'?>" href="?guid=<?=$_GET['guid']?>&page=<?=$i-1?>"><img src="img/left.png"></a>
      <div class="card bg-mdark col-2 mx-1">
        <div class="card-body text-center">
          <p>Miner</p>
          <h2 class="font-weight-bold" onclick="window.location='?guid=<?=$row['guid']?>&page=<?=$_GET['page']?>'"><?=$row['guid']?></h2>
        </div>
      </div>
      <a class="align-self-center mx-2 <?=$i<$cnt-1?'':'d-none'?>" href="?guid=<?=$_GET['guid']?>&page=<?=$i+1?>"><img src="img/right.png"></a>

      <?
      }
      ?>
    </div>
    <p class="text-center"><?=$_GET['guid']?$_GET['guid'].' SELECTED':'SELECT YOUR MINER'?></p>
    <div class="container-fluid <?=$_GET['guid']?'':'d-none'?>">
      <div class="row justify-content-center">
        <div class="card bg-mdark col-4 ml-2 mt-5 text-center">
          <p class="mt-2">POWER CONTROL</p>
          <div class="card-body text-center align-items-center row">
            <div class="col btn btn-outline-dark">
              <a class="fas fa-power-off fa-5x color-primary" onclick="addjob('1','<?=$_GET['guid']?>');"></a>
            </div>
            <div class="col btn btn-outline-dark">
              <a class="fas fa-sync-alt fa-5x color-primary" onclick="addjob('2','<?=$_GET['guid']?>');"></a>
            </div>
          </div>
        </div>
        <div class="card bg-mdark col-4 ml-2 mt-5 text-center">
          <p class="mt-2">Update Miner</p>
          <div class="card-body text-center align-items-center">
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <span class="input-group-text" id="basic-addon1">Coin</span>
                </div>
                <input type="text" class="form-control bg-mdark text-light" name="coin" placeholder="ETP" aria-label="Coin" aria-describedby="basic-addon1">
              </div>
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <span class="input-group-text" id="basic-addon1">Address</span>
                </div>
                <input type="text" class="form-control bg-mdark text-light" name="address" placeholder="MK8T36i5ypcKngR47PS8KTKxwgNX5SQNJC" aria-label="Address" aria-describedby="basic-addon1">
              </div>
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <span class="input-group-text" id="basic-addon1">Pool Info</span>
                </div>
                <input type="text" class="form-control bg-mdark text-light" name="pool" placeholder="etp-kor1.topmining.co.kr:8008" aria-label="Pool" aria-describedby="basic-addon1">
              </div>
              <a class="btn btn-outline-primary btn-block mb-3 text-white" onclick="updateminer();">Update</a>
          </div>
        </div>
      </div>

      <div class="row justify-content-center">
        <div class="card bg-mdark col-4 ml-2 my-5 text-center">
          <p class="mt-2">Overclock Rate</p>
          <div class="card-body text-center align-items-center">
            <div class="input-group mb-3">
              <div class="input-group-prepend">
                <span class="input-group-text" id="basic-addon1">Fan</span>
              </div>
              <input type="text" class="form-control bg-mdark text-light" name="fan" placeholder="100" aria-label="Coin" aria-describedby="basic-addon1">
            </div>
            <div class="input-group mb-3">
              <div class="input-group-prepend">
                <span class="input-group-text" id="basic-addon1">Core</span>
              </div>
              <input type="text" class="form-control bg-mdark text-light" name="core" placeholder="150" aria-label="Address" aria-describedby="basic-addon1">
            </div>
            <div class="input-group mb-3">
              <div class="input-group-prepend">
                <span class="input-group-text" id="basic-addon1">Memory</span>
              </div>
              <input type="text" class="form-control bg-mdark text-light" name="pool" placeholder="400" aria-label="Pool" aria-describedby="basic-addon1">
            </div>
            <a class="btn btn-outline-primary btn-block mb-3 text-white">Update</a>
          </div>
        </div>
        <div class="card bg-mdark col-4 ml-2 my-5 text-center">
          <p class="mt-2">Recent Commands</p>
          <div class="card-body text-center align-items-center">
            <ul class="list-group">
              <?
              $query = "SELECT * FROM jobs WHERE uid='$_SESSION[user_id]' AND done='0' AND guid='$_GET[guid]' ORDER BY id DESC";
              $result = mysqli_query($con, $query);
              for($i=0;$row=mysqli_fetch_array($result),$i<5;$i++){
              ?>
              <li class="list-group-item bg-dark text-white text-left"><?=$arr_jobnum_to_eng[substr($row['jobstring'],0,1)]?></li>
              <?
              }
              ?>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <!-- JavaScript -->
    <script>
      function addjob(jobstr,guid){
        location.href="addjob.php?job="+jobstr+"&guid="+guid+"&user_id=<?=$_SESSION['user_id']?>";
      }
      function updateminer(){
        var jobstr = "3|"+$('[name=coin]').val()+"|"+$('[name=address]').val()+"|"+$('[name=pool]').val()+"|phoenix";
        addjob(jobstr,'<?=$_GET['guid']?>');
      }
    </script>
    <!-- Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
  </body>
</html>