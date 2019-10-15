<?
include_once("member/settings.php");


$query = "SELECT sum(hashrate) as totalhash FROM miners WHERE uid='$_SESSION[user_id]'";
$result = mysqli_query($con, $query);
$totalhash=mysqli_fetch_assoc($result)['totalhash'];

$query = "SELECT count(*) as minercnt FROM miners WHERE uid='$_SESSION[user_id]'";
$result = mysqli_query($con, $query);
$minercnt=mysqli_fetch_assoc($result)['minercnt'];
?>
<!doctype html>
<html class="h-100">
  <head>
    <title>CoinBucc Dashboard</title>
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
          <li class="nav-item active">
            <a class="nav-link" href="dashboard.php">Dashboard</a>
          </li>
          <li class="nav-item">
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
      <a class="align-self-center mr-2"><img src="img/left.png"></a>
      <div class="card bg-mdark col-2 mx-1">
        <div class="card-body text-center">
          <p>Miners</p>
          <h3><?=$minercnt?></h3>
        </div>
      </div>
      <div class="card bg-mdark col-2 mx-1">
        <div class="card-body text-center">
          <p>Value per BTC</p>
          <h3>$8003.4</h3>
        </div>
      </div>
      <div class="card bg-mdark col-2 mx-1">
        <div class="card-body text-center">
          <p>Add Content</p>
          <img class="img-fluid" style="height:40px;" src="img/+.png">
          <!-- 백엔드에서 건드릴 필요 없습니다~ -->
        </div>
      </div>
      <a class="align-self-center ml-2"><img src="img/right.png"></a>
    </div>
    <div class="container-fluid">
      <div class="row justify-content-center">
        <div class="card bg-mdark col-4 ml-2 mt-5 text-center">
          <p class="mt-2">WORKING CONDITION</p>
          <div class="card-body text-center align-items-center">
            <h5><?=$minercnt?> of <?=$minercnt?></h5>
            <h5>100%</h5>
            <p>WORKING</p>
          </div>
        </div>
        <div class="card bg-mdark col-4 ml-2 mt-5 text-center">
          <p class="mt-2">ELECTRONIC CONSUMPTION</p>
          <div class="card-body text-center align-items-center">
            <h1>504.1 w</h1>
          </div>
        </div>
      </div>

      <div class="row justify-content-center">
        <div class="card bg-mdark col-4 ml-2 my-5 text-center">
          <p class="mt-2">TOTAL HASHRATE</p>
          <div class="card-body text-center align-items-center">
              <div class="row"><h1 class="col"><?=$totalhash?> Mh/s</h1></div>
          </div>
        </div>
        <div class="card bg-mdark col-4 ml-2 my-5 text-center">
          <p class="mt-2">TOP MINERs</p>
          <div class="card-body text-center align-items-center">
            <ul class="list-group">
              <?
              $query = "SELECT * FROM miners WHERE uid='$_SESSION[user_id]'";
              $result = mysqli_query($con, $query);
              for($i=0;$row=mysqli_fetch_array($result),$i<3;$i++){
              ?>
              <li class="list-group-item bg-dark text-white text-center"><?=$row['minername']?> - <?=$row['hashrate']?> Mh/s</li>
              <?
              }
              ?>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <!-- JavaScript -->
    <!-- Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
  </body>
</html>