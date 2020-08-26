<?php

	// Change these to connect to the database.
    //	$con  = mysqli_connect('localhost', 'root', '', 'boatgame');
    $con  = mysqli_connect('test.cnrbaforsveg.us-east-1.rds.amazonaws.com', 'admin', 'rootroot', '3dprogramming');

    // Check that conection happened
	if (mysqli_connect_errno())
	{
		echo "1: Could not connect to the database";
		exit();
	}

	$username = $_POST["name"];
	$password = $_POST["password"];

	// This deals with the username
	$namecheckquery = "SELECT username, hash, salt FROM players WHERE username='" . $username . "';";
	$namecheck = mysqli_query($con, $namecheckquery);
	
	//	if(mysqli_num_rows($namecheck) != 1)

	// Get log in info from query
	$existinginfo = mysqli_fetch_assoc($namecheck);
	$salt = $existinginfo["salt"];
	$hash = $existinginfo["hash"];

	$loginhash = crypt($password, $salt);
	if($hash != $loginhash){
    	echo "4: Incorrect password"; // Error code #6 - password does not match to match table
    	exit();
	}
	
	echo "0";
?>
