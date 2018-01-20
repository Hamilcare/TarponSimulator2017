node {
  def app

  stage('Fetch repository') {
    deleteDir()
    checkout scm
  }

  stage('Create build environment') {
    app = docker.build("barnab2/tarpon")
  }

  stage('Build project') {
    app.inside {
      withEnv(["HOME=${ pwd() }"]) {
        sh 'nuget restore ./TarponSimulator2017.sln'
        sh "mdtool build --target:Build '--configuration:Release|x86' --project:TarponSimulator2017"
      }
      sh 'ln -s TarponSimulator2017/bin/Release/ TarponSim2017'
      sh 'cp /opt/sdl2-win32/SDL2.dll ./TarponSim2017/'
      sh 'zip -r TarponSimulator2017.zip TarponSim2017'
      archiveArtifacts artifacts: 'TarponSimulator2017.zip'

      withEnv(["HOME=${ pwd() }"]) {
        sh 'nunit-console26 ./TarponSimulator2017/bin/Release/TarponSimulator2017.exe'
      }
    }
  }
}

