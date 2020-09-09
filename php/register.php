<?php

	// Change these to connect to the database.
    // $con  = mysqli_connect('localhost', 'root', '', 'boatgame');
    $con  = mysqli_connect('******************', '**********', '**********', '3dprogramming');


    // Check that conection happened
	if (mysqli_connect_errno())
	{
		echo "1: Could not connect to the database";
		exit();
	}

	$username = $_POST["name"];
	$password = $_POST["password"];

	// This deals with the username
	$namecheckquery = "SELECT username FROM players WHERE username='" . $username . "';";
	$namecheck = mysqli_query($con, $namecheckquery);
	if (mysqli_num_rows($namecheck) > 0)
	{
		echo "2: Username already taken" . $username . $password;
		exit();
	}

	// This deals with the password 
	$salt = "\$5\$rounds=5000\$" . "thisisasalt" . $username . "\$";
	$hash = crypt($password, $salt);
	$insertplayerstatsquery = "INSERT INTO players (username, hash, salt) VALUES ('". $username . "', '" . $hash . "', '" . $salt ."');" or die("3: Insert playerstats failed");
	mysqli_query($con, $insertplayerstatsquery);

	echo "0";
?>
