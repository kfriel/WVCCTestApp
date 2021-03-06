# Gist4u2, by Jacob Gable (http://jacob4u2.blogspot.com)
# Licensed under Ms-PL; I Don't care about attribution, it's all yours.

function global:List-Gists {
    param ([string]$user = '')
    
    # Serializer
    $extAssembly = [Reflection.Assembly]::LoadWithPartialName("System.Web.Extensions")    
    $serializer = New-Object System.Web.Script.Serialization.JavaScriptSerializer

    # Json downloader
    $webClient = New-Object System.Net.WebClient

    # Json Parser
    function parseJson([string]$json, [bool]$throwError = $true) {    
        try {
            $result = $serializer.DeserializeObject( $json );    
            return $result;
        } catch {                
            if($throwError) { throw "ERROR: Parsing Error"}
            else { return $null }            
        }
    }

    function downloadString([string]$stringUrl) {
        try {        
            return $webClient.DownloadString($stringUrl)
        } catch {         
            throw "ERROR: Problem downloading from $stringUrl"
        }
    }

    function parseUrl([string]$url) {
        return parseJson(downloadString($url));
    }
    
    function downloadUserGists([string]$userName) {
        $gistUserListUrlForm = "http://gist.github.com/api/v1/json/gists/{0}";
        return parseUrl([string]::Format($gistUserListUrlForm, $userName))
    }

    if([string]::IsNullOrEmpty($user)) {
        'ERROR: Must Specify User'
    }
    else {
        "Fetching Gists..."
        $userGists = downloadUserGists($user)
        if($userGists -eq $null) {
            'ERROR: Nothing Found'
        }
        else {
            $userGists.gists | % { 
                $names = ''
                $_.files | % { 
                    $names = "$names, $_"
                }
                [string]::Format("Id({0}): Files[{1}]", $_.repo, $names.SubString(2))
            }
        }        
    }
}

function global:Gist-Info {
    param ([string]$gistId = '')
    
    # Serializer
    $extAssembly = [Reflection.Assembly]::LoadWithPartialName("System.Web.Extensions")    
    $serializer = New-Object System.Web.Script.Serialization.JavaScriptSerializer

    # Json downloader
    $webClient = New-Object System.Net.WebClient

    # Json Parser
    function parseJson([string]$json, [bool]$throwError = $true) {    
        try {
            $result = $serializer.DeserializeObject( $json );    
            return $result;
        } catch {                
            if($throwError) { throw "ERROR: Parsing Error"}
            else { return $null }            
        }
    }

    function downloadString([string]$stringUrl) {
        try {        
            return $webClient.DownloadString($stringUrl)
        } catch {         
            throw "ERROR: Problem downloading from $stringUrl"
        }
    }

    function parseUrl([string]$url) {
        return parseJson(downloadString($url));
    }    
    
    function downloadGistInfo([string]$gistId) {
        $gistInfoUrlForm = "http://gist.github.com/api/v1/json/{0}";
        return parseUrl([string]::Format($gistInfoUrlForm, $gistId))
    }
    
    if([string]::IsNullOrEmpty($gistId)) {
        "ERROR: Must Provide Gist Id"
        return;
    }
    
    "Fetching Gist..."
    $gist = downloadGistInfo($gistId)
    if($gist -eq $null -or $gist.gists -eq $null -or $gist.gists.Length -lt 1) {
        "ERROR: Gist Not Found with Id $gistId"
        return;
    }
    
    $g = $gist.gists[0]    
    
    $repo = $g.repo    
    $owner = $g.owner    
    $created_at = $g.created_at
    $description = $g.description
    "         Id: $repo"
    "      Owner: $owner"
    "    Created: $created_at"
    "Description: $description"
    "      Files: "
    $g.files | % { "           - $_" }
}

function global:Gist-Contents {
    param ([string]$gistId = '', [string]$fileName = '')
    
    # Serializer
    $extAssembly = [Reflection.Assembly]::LoadWithPartialName("System.Web.Extensions")    
    $serializer = New-Object System.Web.Script.Serialization.JavaScriptSerializer

    # Json downloader
    $webClient = New-Object System.Net.WebClient

    # Json Parser
    function parseJson([string]$json, [bool]$throwError = $true) {    
        try {
            $result = $serializer.DeserializeObject( $json );    
            return $result;
        } catch {                
            if($throwError) { throw "ERROR: Parsing Error"}
            else { return $null }            
        }
    }

    function downloadString([string]$stringUrl) {
        try {        
            return $webClient.DownloadString($stringUrl)
        } catch {         
            throw "ERROR: Problem downloading from $stringUrl"
        }
    }

    function parseUrl([string]$url) {
        return parseJson(downloadString($url));
    }
    
    function downloadGistFile([string]$gid, [string]$fname) {
        $gistContentsUrlForm = "http://gist.github.com/raw/{0}/{1}";
        return downloadString([string]::Format($gistContentsUrlForm, $gid, $fname))
    }
    
    if([string]::IsNullOrEmpty($gistId)) { 
        "ERROR: Must provide Gist Id"
        return;
    }
    elseif([string]::IsNullOrEmpty($fileName)) {
        "ERROR: Must provide file name"
        return;
    }    
    
    "Fetching Gist..."
    $file = downloadGistFile $gistId $fileName
    
    return $file
}

function global:Gist-Insert {
    param ([string]$gistId = '', [string]$fileName = '')
    
    # Serializer
    $extAssembly = [Reflection.Assembly]::LoadWithPartialName("System.Web.Extensions")    
    $serializer = New-Object System.Web.Script.Serialization.JavaScriptSerializer

    # Json downloader
    $webClient = New-Object System.Net.WebClient

    # Json Parser
    function parseJson([string]$json, [bool]$throwError = $true) {    
        try {
            $result = $serializer.DeserializeObject( $json );    
            return $result;
        } catch {                
            if($throwError) { throw "ERROR: Parsing Error"}
            else { return $null }            
        }
    }

    function downloadString([string]$stringUrl) {
        try {        
            return $webClient.DownloadString($stringUrl)
        } catch {         
            throw "ERROR: Problem downloading from $stringUrl"
        }
    }

    function parseUrl([string]$url) {
        return parseJson(downloadString($url));
    }
    
    function downloadGistFile([string]$gid, [string]$fname) {
        $gistContentsUrlForm = "http://gist.github.com/raw/{0}/{1}";
        return downloadString([string]::Format($gistContentsUrlForm, $gid, $fname))
    }
    
    function downloadGistInfo([string]$gistId) {
        $gistInfoUrlForm = "http://gist.github.com/api/v1/json/{0}";
        return parseUrl([string]::Format($gistInfoUrlForm, $gistId))
    }
    
    if([string]::IsNullOrEmpty($gistId)) { 
        "ERROR: Must provide Gist Id"
        return;
    }
    elseif([string]::IsNullOrEmpty($fileName)) {
        $gist = downloadGistInfo($gistId)
        if($gist -eq $null -or $gist.gists -eq $null -or $gist.gists.Length -lt 1) {
            "ERROR: Gist Not Found with Id $gistId"
            return;
        }        
        $fileName = $gist.gists[0].files[0]
        "WARN: No file name provided, defaulting to first file [$fileName]"
    }
    
    "Fetching Gist... $fileName"
    $contents = downloadGistFile $gistId $fileName
    if($dte -eq $null -or $dte.ActiveDocument -eq $null -or $dte.ActiveDocument.Selection -eq $null) {
        "ERROR: Cannot Insert into Document, make sure a document is open and the cursor is where you want the file inserted."
        return;
    }
    
    "Inserting Gist..."
    $tempName = [System.IO.Path]::GetTempFileName()
    Set-Content $tempName $contents
    
    $dte.ActiveDocument.Selection.InsertFromFile($tempName)
    $dte.ActiveDocument.Selection.SelectAll()
    $dte.ActiveDocument.Selection.SmartFormat()
    
    del $tempName
}