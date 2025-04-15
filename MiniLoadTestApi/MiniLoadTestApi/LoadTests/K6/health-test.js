import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    vus: 10, // تعداد کاربران همزمان
    duration: '10s', // مدت اجرای تست
};

export default function () {
    const url = 'http://localhost:5019/health';
    //const payload = JSON.stringify({
    //    username: 'yourUsername',
    //    password: 'yourPassword',
    //});

    //const params = {
    //    headers: {
    //        'Content-Type': 'application/json',
    //    },
    //};

    //const res = http.post(url, payload, params);
    const res = http.get(url);

    check(res, {
        'status was 200': (r) => r.status === 200,
    });

    sleep(1); // یک ثانیه صبر برای هر یوزر
}
