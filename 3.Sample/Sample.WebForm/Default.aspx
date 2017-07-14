<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Webuploader Demo</title>
    <link href="/content/webuploader/webuploader.css" rel="stylesheet" />
    <link href="/content/demo.css" rel="stylesheet" />
</head>
<body>

    <div class="page-container">
        <div id="uploader" class="wu-example">
            <div class="queueList">
                <div id="dndArea" class="placeholder">
                    <div id="filePicker"></div>
                    <p>或将照片拖到这里，单次最多可选300张</p>
                </div>
            </div>
            <div class="statusBar" style="display: none;">
                <div class="progress">
                    <span class="text">0%</span>
                    <span class="percentage"></span>
                </div>
                <div class="info"></div>
                <div class="btns">
                    <div id="filePicker2"></div>
                    <div class="uploadBtn">开始上传</div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        // 添加全局站点信息
        var BASE_URL = '/webuploader';
    </script>
    <script src="/content/jquery.js"></script>
    <script src="/content/webuploader/webuploader.min.js"></script>
    <script src="/content/demo.js"></script>
</body>
</html>
