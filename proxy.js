const net = require('net');

// Cấu hình cổng nhận nội bộ và cổng đích ở công ty bạn
const LOCAL_PORT = 1433; 
const REMOTE_PORT = 48261;
const REMOTE_HOST = 'hieusachcuonghuong.cameraddns.net';

const server = net.createServer((socket) => {
    // Khi C# gọi vào localhost:1433, Node.js sẽ bắt cầu nối thẳng về công ty
    const client = net.createConnection(REMOTE_PORT, REMOTE_HOST, () => {
        socket.pipe(client);
        client.pipe(socket);
    });

    socket.on('error', (err) => client.end());
    client.on('error', (err) => socket.end());
});

server.listen(LOCAL_PORT, '127.0.0.1', () => {
    console.log(`Cầu nối bảo mật đang chạy tại localhost:${LOCAL_PORT}`);
});
