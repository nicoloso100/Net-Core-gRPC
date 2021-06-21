import * as jspb from 'google-protobuf'

import * as google_protobuf_timestamp_pb from 'google-protobuf/google/protobuf/timestamp_pb';


export class TicketRequestId extends jspb.Message {
  getId(): string;
  setId(value: string): TicketRequestId;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): TicketRequestId.AsObject;
  static toObject(includeInstance: boolean, msg: TicketRequestId): TicketRequestId.AsObject;
  static serializeBinaryToWriter(message: TicketRequestId, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): TicketRequestId;
  static deserializeBinaryFromReader(message: TicketRequestId, reader: jspb.BinaryReader): TicketRequestId;
}

export namespace TicketRequestId {
  export type AsObject = {
    id: string,
  }
}

export class AllTicketsRequest extends jspb.Message {
  getPage(): number;
  setPage(value: number): AllTicketsRequest;

  getCount(): number;
  setCount(value: number): AllTicketsRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): AllTicketsRequest.AsObject;
  static toObject(includeInstance: boolean, msg: AllTicketsRequest): AllTicketsRequest.AsObject;
  static serializeBinaryToWriter(message: AllTicketsRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): AllTicketsRequest;
  static deserializeBinaryFromReader(message: AllTicketsRequest, reader: jspb.BinaryReader): AllTicketsRequest;
}

export namespace AllTicketsRequest {
  export type AsObject = {
    page: number,
    count: number,
  }
}

export class AddTicketRequest extends jspb.Message {
  getUser(): string;
  setUser(value: string): AddTicketRequest;

  getStatus(): boolean;
  setStatus(value: boolean): AddTicketRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): AddTicketRequest.AsObject;
  static toObject(includeInstance: boolean, msg: AddTicketRequest): AddTicketRequest.AsObject;
  static serializeBinaryToWriter(message: AddTicketRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): AddTicketRequest;
  static deserializeBinaryFromReader(message: AddTicketRequest, reader: jspb.BinaryReader): AddTicketRequest;
}

export namespace AddTicketRequest {
  export type AsObject = {
    user: string,
    status: boolean,
  }
}

export class EditTicketRequest extends jspb.Message {
  getId(): string;
  setId(value: string): EditTicketRequest;

  getUser(): string;
  setUser(value: string): EditTicketRequest;

  getStatus(): boolean;
  setStatus(value: boolean): EditTicketRequest;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): EditTicketRequest.AsObject;
  static toObject(includeInstance: boolean, msg: EditTicketRequest): EditTicketRequest.AsObject;
  static serializeBinaryToWriter(message: EditTicketRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): EditTicketRequest;
  static deserializeBinaryFromReader(message: EditTicketRequest, reader: jspb.BinaryReader): EditTicketRequest;
}

export namespace EditTicketRequest {
  export type AsObject = {
    id: string,
    user: string,
    status: boolean,
  }
}

export class TicketReply extends jspb.Message {
  getId(): string;
  setId(value: string): TicketReply;

  getUser(): string;
  setUser(value: string): TicketReply;

  getCreationdate(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setCreationdate(value?: google_protobuf_timestamp_pb.Timestamp): TicketReply;
  hasCreationdate(): boolean;
  clearCreationdate(): TicketReply;

  getUpdatedate(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setUpdatedate(value?: google_protobuf_timestamp_pb.Timestamp): TicketReply;
  hasUpdatedate(): boolean;
  clearUpdatedate(): TicketReply;

  getStatus(): boolean;
  setStatus(value: boolean): TicketReply;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): TicketReply.AsObject;
  static toObject(includeInstance: boolean, msg: TicketReply): TicketReply.AsObject;
  static serializeBinaryToWriter(message: TicketReply, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): TicketReply;
  static deserializeBinaryFromReader(message: TicketReply, reader: jspb.BinaryReader): TicketReply;
}

export namespace TicketReply {
  export type AsObject = {
    id: string,
    user: string,
    creationdate?: google_protobuf_timestamp_pb.Timestamp.AsObject,
    updatedate?: google_protobuf_timestamp_pb.Timestamp.AsObject,
    status: boolean,
  }
}

export class TicketsReply extends jspb.Message {
  getRows(): number;
  setRows(value: number): TicketsReply;

  getTicketsList(): Array<TicketReply>;
  setTicketsList(value: Array<TicketReply>): TicketsReply;
  clearTicketsList(): TicketsReply;
  addTickets(value?: TicketReply, index?: number): TicketReply;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): TicketsReply.AsObject;
  static toObject(includeInstance: boolean, msg: TicketsReply): TicketsReply.AsObject;
  static serializeBinaryToWriter(message: TicketsReply, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): TicketsReply;
  static deserializeBinaryFromReader(message: TicketsReply, reader: jspb.BinaryReader): TicketsReply;
}

export namespace TicketsReply {
  export type AsObject = {
    rows: number,
    ticketsList: Array<TicketReply.AsObject>,
  }
}

