(function () {
    var engine = new Engine();

    document.getElementById('guess').addEventListener('click', engine.onGuessClick);
    document.getElementById('new').addEventListener('click', engine.onNewGameClick);
    document.getElementById('score').addEventListener('click', engine.onHighScoreClick);
    document.getElementById('msg-btn').addEventListener('click', engine.saveToHighScore);
    document.getElementById('hs-exit').addEventListener('click', engine.onHighScoreExitClick);
    document.getElementById('hs-clear').addEventListener('click', engine.onHighScoreClearClick);
    engine.start();
}());