# Pemanfaatan Pattern Matching dalam Membangun Sistem Deteksi Individu Berbasis Biometrik Melalui Citra Sidik Jari

> Tugas Besar Strategi Algoritma Kelompok Last day on ITB **[Tubes3_Last-day-on-ITB]**
>
> Oleh Kelompok Last day on ITB:<br>
> 1. 13522049 Vanson Kurnialim<br>
> 2. 13522090 Fedrianz Dharma<br>
> 3. 13522094 Andhika Tantyo Anugrah<br>
>
> Sekolah Teknik Elektro dan Informatika<br>
> Institut Teknologi Bandung<br>
> Semester IV Tahun 2023/2024


## Table of Contents
* [General Info](#general-information)
* [Features](#features)
* [Requirements](#requirements)
* [Usage](#usage)
* [Acknowledgements](#acknowledgements)
* [Links](#links)


## General Information
Salah satu teknologi biometrik yang banyak digunakan adalah identifikasi sidik jari. Sidik jari setiap orang memiliki pola yang unik dan tidak dapat ditiru, sehingga cocok untuk digunakan sebagai identitas individu.

Pattern matching merupakan teknik penting dalam sistem identifikasi sidik jari. Teknik ini digunakan untuk mencocokkan pola sidik jari yang ditangkap dengan pola sidik jari yang terdaftar di database. Algoritma pattern matching yang umum digunakan adalah Bozorth dan Boyer-Moore.

Pada project ini, kami akan menggunakan algoritma Boyer-Moore dan Knuth-Morris-Pratt untuk mencocokan pola pada sidik jari.



## Features
- Pemilihan algoritma yang digunakan antara Boyer-Moore atau Knuth-Morris-Pratt
- Menampilkan hasil citra sidik jari yang paling mirip dengan citra sidik jari input, tingkat kemiripan, dan biodata yang terhubung dengan sidik jari tersebut
- Fungsi enkripsi dan dekripsi yang digunakan pada database
- GUI untuk mengakomodasi interaksi antara pengguna dengan aplikasi


## Requirements
1. Install .NET https://dotnet.microsoft.com/id-id/download/dotnet/thank-you/sdk-8.0.301-windows-x64-installer
2. Install Docker dan nyalakan docker dengan command
`docker-compose up -d`
2. Uninstall Mariadb
3. Jika ingin menggunakan file sql lain, letakan file pada folder src/backend/database dan jalankan command `iconv -f utf-16 -t utf-8 [nama file].sql > stima_encrypt_utf-8.sql` menggunakan wsl.
4. Jalankan `docker-compose down -v` untuk menghapus volume pada docker. 

## Usage

1. Setelah docker aktif, jalankan `dotnet run --project src/frontend` untuk menjalankan aplikasi dengan GUI.
2. Upload citra sidik jari yang ingin digunakan.
3. Pilih algoritma yang ingin digunakan.
4. Klik tombol search dan tunggu hasil.

## Acknowledgements
- This project was based on [Tugas Besar 3 IF2211 Strategi Algoritma Semester II tahun 2023/2024](https://docs.google.com/document/d/15Dk7FbcraVDCYDYtT6d743h649ZMN6xE/edit).
- Many thanks to everyone who's helped us in developing this assignment.


## Links
- [Tugas Besar 3 IF2211 Strategi Algoritma Semester II tahun 2023/2024](https://docs.google.com/document/d/15Dk7FbcraVDCYDYtT6d743h649ZMN6xE/edit)
- [This Repository](https://github.com/CrystalNoob/Tubes3_Last-day-on-ITB)
- [The Report](https://docs.google.com/document/d/1SFLd8xM8HPhVgEdfM-HLrRCQ8aOkbLk9Jr1tx8dcsxs/edit)
