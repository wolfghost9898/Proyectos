/****************************************************************************
** Meta object code from reading C++ file 'timergame.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.9.2)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../Proyecto1_EDD/timergame.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'timergame.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.9.2. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
struct qt_meta_stringdata_timerGame_t {
    QByteArrayData data[7];
    char stringdata0[65];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_timerGame_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_timerGame_t qt_meta_stringdata_timerGame = {
    {
QT_MOC_LITERAL(0, 0, 9), // "timerGame"
QT_MOC_LITERAL(1, 10, 11), // "workRequest"
QT_MOC_LITERAL(2, 22, 0), // ""
QT_MOC_LITERAL(3, 23, 8), // "finished"
QT_MOC_LITERAL(4, 32, 11), // "updateTimer"
QT_MOC_LITERAL(5, 44, 13), // "cambiarTiempo"
QT_MOC_LITERAL(6, 58, 6) // "doWork"

    },
    "timerGame\0workRequest\0\0finished\0"
    "updateTimer\0cambiarTiempo\0doWork"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_timerGame[] = {

 // content:
       7,       // revision
       0,       // classname
       0,    0, // classinfo
       5,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       4,       // signalCount

 // signals: name, argc, parameters, tag, flags
       1,    0,   39,    2, 0x06 /* Public */,
       3,    0,   40,    2, 0x06 /* Public */,
       4,    0,   41,    2, 0x06 /* Public */,
       5,    0,   42,    2, 0x06 /* Public */,

 // slots: name, argc, parameters, tag, flags
       6,    0,   43,    2, 0x0a /* Public */,

 // signals: parameters
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,

 // slots: parameters
    QMetaType::Void,

       0        // eod
};

void timerGame::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        timerGame *_t = static_cast<timerGame *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->workRequest(); break;
        case 1: _t->finished(); break;
        case 2: _t->updateTimer(); break;
        case 3: _t->cambiarTiempo(); break;
        case 4: _t->doWork(); break;
        default: ;
        }
    } else if (_c == QMetaObject::IndexOfMethod) {
        int *result = reinterpret_cast<int *>(_a[0]);
        void **func = reinterpret_cast<void **>(_a[1]);
        {
            typedef void (timerGame::*_t)();
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&timerGame::workRequest)) {
                *result = 0;
                return;
            }
        }
        {
            typedef void (timerGame::*_t)();
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&timerGame::finished)) {
                *result = 1;
                return;
            }
        }
        {
            typedef void (timerGame::*_t)();
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&timerGame::updateTimer)) {
                *result = 2;
                return;
            }
        }
        {
            typedef void (timerGame::*_t)();
            if (*reinterpret_cast<_t *>(func) == static_cast<_t>(&timerGame::cambiarTiempo)) {
                *result = 3;
                return;
            }
        }
    }
    Q_UNUSED(_a);
}

const QMetaObject timerGame::staticMetaObject = {
    { &QObject::staticMetaObject, qt_meta_stringdata_timerGame.data,
      qt_meta_data_timerGame,  qt_static_metacall, nullptr, nullptr}
};


const QMetaObject *timerGame::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *timerGame::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_timerGame.stringdata0))
        return static_cast<void*>(this);
    return QObject::qt_metacast(_clname);
}

int timerGame::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QObject::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 5)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 5;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 5)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 5;
    }
    return _id;
}

// SIGNAL 0
void timerGame::workRequest()
{
    QMetaObject::activate(this, &staticMetaObject, 0, nullptr);
}

// SIGNAL 1
void timerGame::finished()
{
    QMetaObject::activate(this, &staticMetaObject, 1, nullptr);
}

// SIGNAL 2
void timerGame::updateTimer()
{
    QMetaObject::activate(this, &staticMetaObject, 2, nullptr);
}

// SIGNAL 3
void timerGame::cambiarTiempo()
{
    QMetaObject::activate(this, &staticMetaObject, 3, nullptr);
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE
