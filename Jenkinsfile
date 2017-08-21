node {
  def app

  stage('Create build environment') {
    checkout scm
    app = docker.build("barnab2/tarpon")
  }

  stage('Build project') {
    app.inside {
      checkout scm
      sh "mdtool build --target:Build '--configuration:Release|x86' --project:TarponSimulator2017"
      sh 'ln -s TarponSimulator2017/bin/Release/ TarponSim2017'
      sh 'zip -r TarponSim2017 TarponSimulator2017.zip'
      archiveArtifacts artifacts: 'TarponSimulator2017.zip'
    }
  }


