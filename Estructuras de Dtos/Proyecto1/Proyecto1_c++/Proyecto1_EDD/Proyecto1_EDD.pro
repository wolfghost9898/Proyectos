#-------------------------------------------------
#
# Project created by QtCreator 2018-03-05T14:52:57
#
#-------------------------------------------------

QT       += core gui
QMAKE_CXXFLAGS += -std=c++0x -DHAVE_INTTYPES_H -DHAVE_NETINET_IN_H -Wall
INCLUDEPATH += -I/usr/local/include/thrift
LIBS+= -L/usr/local/lib -lthrift
greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = Proyecto1_EDD
TEMPLATE = app

# The following define makes your compiler emit warnings if you use
# any feature of Qt which has been marked as deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if you use deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0


SOURCES += \
        main.cpp \
        mainwindow.cpp \
    niveles.cpp \
    gen-cpp/Proyecto1_server.skeleton.cpp \
    gen-cpp/Proyecto1.cpp \
    gen-cpp/servidor_constants.cpp \
    gen-cpp/servidor_types.cpp \
    mythread.cpp \
    generarenemigos.cpp \
    frontend.cpp \
    startenemigos.cpp \
    timergame.cpp \
    moveenemigos.cpp \
    puntajes.cpp

HEADERS += \
        mainwindow.h \
    auxiliar.h \
    niveles.h \
    gen-cpp/Proyecto1.h \
    gen-cpp/servidor_constants.h \
    gen-cpp/servidor_types.h \
    mythread.h \
    generarenemigos.h \
    frontend.h \
    startenemigos.h \
    timergame.h \
    moveenemigos.h \
    puntajes.h

FORMS += \
        mainwindow.ui \
    niveles.ui \
    frontend.ui \
    puntajes.ui
