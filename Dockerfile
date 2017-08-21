FROM fedora:latest
LABEL maintainer "quentin@dufour.io"
RUN echo "fastestmirror=1" >> /etc/dnf/dnf.conf \
    && dnf install -y monodevelop zip

# Hotfix for monodevelop that want to access a /.cache folder...
RUN mkdir /.cache && chmod 777 /.cache
