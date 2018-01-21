FROM fedora:latest
LABEL maintainer "quentin@dufour.io"
RUN echo "fastestmirror=1" >> /etc/dnf/dnf.conf \
    && dnf install -y monodevelop zip SDL2 SDL2-devel nuget ca-certificates nunit2

RUN curl https://www.libsdl.org/release/SDL2-2.0.5-win32-x86.zip -o /opt/sdl2-win32.zip \
    && unzip /opt/sdl2-win32.zip -d /opt/sdl2-win32 \
    && cert-sync /etc/pki/tls/certs/ca-bundle.crt

RUN curl http://www.monogame.net/releases/v3.6/monogame-sdk.run -o /opt/monogame-sdk.run \
    && chmod +x /opt/monogame-sdk.run \
    && /opt/monogame-sdk.run
