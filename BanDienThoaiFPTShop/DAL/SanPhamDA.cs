﻿using DTO;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SanPhamDA : ISanPhamDA
    {
        private readonly string _connectionString;

        public SanPhamDA(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connect");
        }

        public void InsertSanPham(SanPhamModel sanPham)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_InsertSanPham", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaChuyenMuc", sanPham.MaChuyenMuc);
                    command.Parameters.AddWithValue("@TenSanPham", sanPham.TenSanPham);
                    command.Parameters.AddWithValue("@AnhDaiDien", sanPham.AnhDaiDien);
                    command.Parameters.AddWithValue("@Gia", sanPham.Gia);
                    command.Parameters.AddWithValue("@GiaGiam", sanPham.GiaGiam);
                    command.Parameters.AddWithValue("@SoLuong", sanPham.SoLuong);
                    command.Parameters.AddWithValue("@TrangThai", sanPham.TrangThai);
                    command.Parameters.AddWithValue("@LuotXem", sanPham.LuotXem);
                    command.Parameters.AddWithValue("@DacBiet", sanPham.DacBiet);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public SanPhamModel GetSanPhamByID(int maSanPham)
        {
            SanPhamModel sanPham = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetSanPhamByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaSanPham", maSanPham);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sanPham = new SanPhamModel
                            {
                                MaSanPham = reader.GetInt32(reader.GetOrdinal("MaSanPham")),
                                MaChuyenMuc = reader.IsDBNull(reader.GetOrdinal("MaChuyenMuc")) ? null : reader.GetInt32(reader.GetOrdinal("MaChuyenMuc")),
                                TenSanPham = reader.GetString(reader.GetOrdinal("TenSanPham")),
                                AnhDaiDien = reader.GetString(reader.GetOrdinal("AnhDaiDien")),
                                Gia = reader.GetDecimal(reader.GetOrdinal("Gia")),
                                GiaGiam = reader.IsDBNull(reader.GetOrdinal("GiaGiam")) ? null : reader.GetDecimal(reader.GetOrdinal("GiaGiam")),
                                SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                LuotXem = reader.GetInt32(reader.GetOrdinal("LuotXem")),
                                DacBiet = reader.GetBoolean(reader.GetOrdinal("DacBiet"))
                            };
                        }
                    }
                }
            }

            return sanPham;
        }

        public void UpdateSanPham(int maSanPham, SanPhamModel sanPham)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_UpdateSanPham", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    command.Parameters.AddWithValue("@MaChuyenMuc", sanPham.MaChuyenMuc);
                    command.Parameters.AddWithValue("@TenSanPham", sanPham.TenSanPham);
                    command.Parameters.AddWithValue("@AnhDaiDien", sanPham.AnhDaiDien);
                    command.Parameters.AddWithValue("@Gia", sanPham.Gia);
                    command.Parameters.AddWithValue("@GiaGiam", sanPham.GiaGiam);
                    command.Parameters.AddWithValue("@SoLuong", sanPham.SoLuong);
                    command.Parameters.AddWithValue("@TrangThai", sanPham.TrangThai);
                    command.Parameters.AddWithValue("@LuotXem", sanPham.LuotXem);
                    command.Parameters.AddWithValue("@DacBiet", sanPham.DacBiet);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSanPham(int maSanPham)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteSanPham", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaSanPham", maSanPham);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<SanPhamModel> GetAllSanPhams()
        {
            List<SanPhamModel> sanPhams = new List<SanPhamModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetAllSanPhams", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamModel sanPham = new SanPhamModel
                            {
                                MaSanPham = reader.GetInt32(reader.GetOrdinal("MaSanPham")),
                                MaChuyenMuc = reader.IsDBNull(reader.GetOrdinal("MaChuyenMuc")) ? null : reader.GetInt32(reader.GetOrdinal("MaChuyenMuc")),
                                TenSanPham = reader.GetString(reader.GetOrdinal("TenSanPham")),
                                AnhDaiDien = reader.GetString(reader.GetOrdinal("AnhDaiDien")),
                                Gia = reader.GetDecimal(reader.GetOrdinal("Gia")),
                                GiaGiam = reader.IsDBNull(reader.GetOrdinal("GiaGiam")) ? null : reader.GetDecimal(reader.GetOrdinal("GiaGiam")),
                                SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                LuotXem = reader.GetInt32(reader.GetOrdinal("LuotXem")),
                                DacBiet = reader.GetBoolean(reader.GetOrdinal("DacBiet"))
                            };
                            sanPhams.Add(sanPham);
                        }
                    }
                }
            }

            return sanPhams;
        }

        public List<SanPhamModel> SearchSanPhams(string keyword, int pageIndex, int pageSize, out long total)
        {
            List<SanPhamModel> sanPhams = new List<SanPhamModel>();
            total = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_SearchSanPhams", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Keyword", keyword);
                    command.Parameters.AddWithValue("@PageIndex", pageIndex);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    var totalParam = command.Parameters.Add("@Total", SqlDbType.BigInt);
                    totalParam.Direction = ParameterDirection.Output;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamModel sanPham = new SanPhamModel
                            {
                                MaSanPham = reader.GetInt32(reader.GetOrdinal("MaSanPham")),
                                MaChuyenMuc = reader.IsDBNull(reader.GetOrdinal("MaChuyenMuc")) ? null : reader.GetInt32(reader.GetOrdinal("MaChuyenMuc")),
                                TenSanPham = reader.GetString(reader.GetOrdinal("TenSanPham")),
                                AnhDaiDien = reader.GetString(reader.GetOrdinal("AnhDaiDien")),
                                Gia = reader.GetDecimal(reader.GetOrdinal("Gia")),
                                GiaGiam = reader.IsDBNull(reader.GetOrdinal("GiaGiam")) ? null : reader.GetDecimal(reader.GetOrdinal("GiaGiam")),
                                SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                LuotXem = reader.GetInt32(reader.GetOrdinal("LuotXem")),
                                DacBiet = reader.GetBoolean(reader.GetOrdinal("DacBiet"))
                            };
                            sanPhams.Add(sanPham);
                        }
                    }

                    total = (long)totalParam.Value;
                }
            }

            return sanPhams;
        }
    }
}
