FROM fedora:latest
LABEL maintainer "quentin@dufour.io"
RUN echo "fastestmirror=1" >> /etc/dnf/dnf.conf \
    && dnf install -y monodevelop zip
